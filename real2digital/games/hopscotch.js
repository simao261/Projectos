export async function mount(host){
  host.innerHTML = '';
  const wrapper = document.createElement('div');
  wrapper.className = 'hop-wrapper';

  const state = {
    round: 1,
    forbidden: null,
    currentStep: 0, // 0 means before casa 1. Steps are 1..10
    path: [1,2,3,4,5,6,7,8,9,10],
    isRunning: false,
    completed: false,
  };

  const panel = document.createElement('div');
  panel.className = 'hop-panel';
  panel.innerHTML = `
    <div class="stat"><span>Rodada</span><strong id="st-round">${state.round}</strong></div>
    <div class="stat"><span>Casa proibida</span><strong id="st-forbidden">—</strong></div>
    <div class="controls">
      <button id="btn-throw" class="button">Lançar pedrinha</button>
      <button id="btn-next" class="button secondary" disabled>Avançar (␣/↵)</button>
      <button id="btn-reset" class="button secondary">Recomeçar</button>
    </div>
    <div class="hint">Objetivo: subir até a casa 10, saltando em sequência e <strong>pulando</strong> a casa proibida. Não é permitido errar a ordem.</div>
    <div id="msg" class="alert" style="display:none"></div>

    <div class="controls-pad" aria-hidden="false">
      <span></span>
      <button class="pad-btn primary" id="pad-next" title="Avançar">↟</button>
      <span></span>
      <span></span>
      <button class="pad-btn" id="pad-throw" title="Lançar">🎯</button>
      <span></span>
    </div>
  `;

  const board = document.createElement('div');
  board.className = 'board';
  const grid = document.createElement('div');
  grid.className = 'hop-grid';

  // Layout (3 cols) for visual amarelinha; center column index 2
  // Row design: [ , 1, ], [2, , 3], [ , 4, ], [5, , 6], [ , 7, ], [8, , 9], [ , 10, ]
  const positions = {
    1: {col: 2, row: 1},
    2: {col: 1, row: 2}, 3: {col: 3, row: 2},
    4: {col: 2, row: 3},
    5: {col: 1, row: 4}, 6: {col: 3, row: 4},
    7: {col: 2, row: 5},
    8: {col: 1, row: 6}, 9: {col: 3, row: 6},
    10: {col: 2, row: 7},
  };

  const tiles = new Map();
  for (const n of state.path){
    const t = document.createElement('div');
    t.className = 'tile';
    t.textContent = String(n);
    t.dataset.n = String(n);
    t.style.gridColumn = String(positions[n].col);
    t.style.gridRow = String(positions[n].row);
    grid.appendChild(t);
    tiles.set(n, t);
  }
  tiles.get(10).classList.add('goal');

  const pathIndicator = document.createElement('div');
  pathIndicator.className = 'path-indicator';
  grid.appendChild(pathIndicator);

  board.appendChild(grid);

  wrapper.appendChild(panel);
  wrapper.appendChild(board);
  host.appendChild(wrapper);

  const els = {
    round: panel.querySelector('#st-round'),
    forb: panel.querySelector('#st-forbidden'),
    btnThrow: panel.querySelector('#btn-throw'),
    btnNext: panel.querySelector('#btn-next'),
    btnReset: panel.querySelector('#btn-reset'),
    msg: panel.querySelector('#msg'),
    padNext: panel.querySelector('#pad-next'),
    padThrow: panel.querySelector('#pad-throw'),
  };

  function showMsg(text, kind='info'){
    els.msg.textContent = text;
    els.msg.className = `alert ${kind==='success'?'success':kind==='error'?'error':''}`;
    els.msg.style.display = 'block';
  }
  function hideMsg(){ els.msg.style.display = 'none'; }

  function updateForbidden(){
    tiles.forEach(t => t.classList.remove('forbidden'));
    if (state.forbidden){
      tiles.get(state.forbidden)?.classList.add('forbidden');
      els.forb.textContent = String(state.forbidden);
    } else {
      els.forb.textContent = '—';
    }
  }

  function updateActive(){
    tiles.forEach(t => t.classList.remove('active'));
    const next = getNextStep();
    if (next !== null){
      tiles.get(next)?.classList.add('active');
    }
  }

  function getNextStep(){
    const nextIdx = state.currentStep + 1;
    const next = state.path[nextIdx - 1] ?? null;
    if (next === state.forbidden) return state.path[nextIdx] ?? null; // skip forbidden
    return next;
  }

  function reset(roundInc=false){
    hideMsg();
    state.currentStep = 0;
    if (roundInc) state.round += 1;
    state.forbidden = null;
    state.isRunning = false;
    state.completed = false;
    els.round.textContent = String(state.round);
    els.btnNext.disabled = true;
    updateForbidden();
    updateActive();
  }

  function throwStone(){
    const available = state.path.filter(n => n !== state.forbidden);
    state.forbidden = available[Math.floor(Math.random()*available.length)];
    state.isRunning = true;
    els.btnNext.disabled = false;
    hideMsg();
    updateForbidden();
    updateActive();
    showMsg(`Casa ${state.forbidden} está proibida nesta rodada. Boa sorte!`);
  }

  function advance(){
    if (!state.isRunning) return;
    const next = getNextStep();
    if (next === null){
      return;
    }
    // Validate that the true next number in sequence is either next or forbidden
    const expectedIdx = state.currentStep + 1;
    const expected = state.path[expectedIdx - 1] ?? null;
    if (expected !== null && expected !== state.forbidden && next !== expected){
      // This should not happen with our logic, but keep guard
      showMsg('Sequência inválida. Recomeçando a rodada.', 'error');
      reset(false);
      updateActive();
      return;
    }

    state.currentStep = next; // move to next allowed tile
    updateActive();

    if (state.currentStep === 10){
      state.completed = true;
      state.isRunning = false;
      els.btnNext.disabled = true;
      showMsg('Parabéns! Você completou a amarelinha! Próxima rodada…', 'success');
      setTimeout(() => reset(true), 1200);
    }
  }

  function keyListener(e){
    if (e.code === 'Space' || e.code === 'Enter'){ e.preventDefault(); advance(); }
  }

  els.btnThrow.addEventListener('click', throwStone);
  els.btnNext.addEventListener('click', advance);
  els.btnReset.addEventListener('click', () => reset(false));
  els.padNext.addEventListener('click', advance);
  els.padThrow.addEventListener('click', throwStone);
  window.addEventListener('keydown', keyListener);

  // Initialize
  reset(false);

  return function unmount(){
    window.removeEventListener('keydown', keyListener);
  };
}