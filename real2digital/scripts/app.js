const appRoot = document.getElementById('app-root');
const yearEl = document.getElementById('year');
if (yearEl) yearEl.textContent = new Date().getFullYear();

let currentUnmount = null;
function setActiveNav(){
  const links = document.querySelectorAll('.main-nav .nav-link');
  links.forEach(l => l.removeAttribute('aria-current'));
  const route = location.hash.replace(/^#/, '');
  const active = route.startsWith('/jogo') || route.startsWith('/jogos') ? '/jogos' : '/';
  const link = Array.from(links).find(a => a.getAttribute('href') === `#${active}`);
  if (link) link.setAttribute('aria-current','page');
}

function renderHome(){
  appRoot.innerHTML = `
    <section class="home-hero">
      <div>
        <h1 class="title">Transforme jogos da vida real em experiências digitais</h1>
        <p class="subtitle">Começamos com a Amarelinha (Jogo da Macaca). Em breve: corda, pião, quatro cantos e mais.</p>
        <div class="CTA">
          <a class="button" href="#/jogo/amarelinha">Jogar Amarelinha</a>
          <a class="button secondary" href="#/jogos">Ver todos os jogos</a>
        </div>
      </div>
      <div class="hero-card">
        <p><strong>Profissional, responsivo e acessível.</strong> Construído para funcionar bem em desktop e mobile, com carregamento modular por jogo.</p>
      </div>
    </section>

    <section class="view" aria-labelledby="jogos-title">
      <h2 id="jogos-title">Jogos disponíveis</h2>
      <div class="card-grid">
        <article class="card">
          <span class="tag">Pronto • Nível 1</span>
          <h3>Amarelinha (Jogo da Macaca)</h3>
          <p>Salte pelas casas e complete o percurso, desviando da casa com pedrinha.</p>
          <div class="card-actions">
            <a class="link" href="#/jogo/amarelinha">Jogar agora →</a>
          </div>
        </article>
        <article class="card" aria-disabled="true">
          <span class="tag">Em breve</span>
          <h3>Pular Corda</h3>
          <p>Ritmo e reflexo em uma corda virtual. Aguarde atualizações.</p>
          <div class="card-actions">
            <span class="link" role="link" aria-disabled="true">Disponível em breve</span>
          </div>
        </article>
        <article class="card" aria-disabled="true">
          <span class="tag">Em breve</span>
          <h3>Quatro Cantos</h3>
          <p>Trocas rápidas de posição, agora na tela. Em breve.</p>
          <div class="card-actions">
            <span class="link" role="link" aria-disabled="true">Disponível em breve</span>
          </div>
        </article>
      </div>
    </section>
  `;
}

function renderGamesIndex(){
  appRoot.innerHTML = `
    <section class="view">
      <h2>Jogos</h2>
      <p class="muted">Escolha um jogo para começar.</p>
      <div class="card-grid">
        <article class="card">
          <span class="tag">Pronto</span>
          <h3>Amarelinha (Jogo da Macaca)</h3>
          <p>Clássico das calçadas, agora digital.</p>
          <div class="card-actions">
            <a class="link" href="#/jogo/amarelinha">Jogar →</a>
          </div>
        </article>
        <article class="card" aria-disabled="true">
          <span class="tag">Em breve</span>
          <h3>Pular Corda</h3>
          <p>Fase de design.</p>
        </article>
      </div>
    </section>
  `;
}

async function renderHopscotch(){
  const view = document.createElement('section');
  view.className = 'view';
  view.innerHTML = `
    <h2>Amarelinha (Jogo da Macaca)</h2>
    <p class="muted">Use Espaço/Enter para avançar nas casas. Clique em "Lançar pedrinha" para escolher a casa proibida da rodada.</p>
    <div id="hop-container"></div>
  `;
  appRoot.innerHTML = '';
  appRoot.appendChild(view);
  const module = await import('../games/hopscotch.js');
  const unmount = await module.mount(document.getElementById('hop-container'));
  currentUnmount = typeof unmount === 'function' ? unmount : null;
}

async function renderRoute(){
  currentUnmount?.();
  const route = location.hash.replace(/^#/, '') || '/';
  setActiveNav();
  if (route === '/' ) return renderHome();
  if (route === '/jogos') return renderGamesIndex();
  if (route === '/jogo/amarelinha') return renderHopscotch();
  // fallback
  renderHome();
}

window.addEventListener('hashchange', renderRoute);
window.addEventListener('DOMContentLoaded', renderRoute);