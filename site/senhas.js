// Variáveis globais
let generatedPasswords = [];
let passwordHistory = [];

// Carregar dados ao iniciar
document.addEventListener('DOMContentLoaded', function() {
    loadPasswordHistory();
    setupEventListeners();
});

// Configurar event listeners
function setupEventListeners() {
    // Atualizar valor do range
    document.getElementById('passwordLength').addEventListener('input', function() {
        document.getElementById('lengthValue').textContent = this.value + ' caracteres';
    });
    
    // Verificar força da senha em tempo real
    document.getElementById('testPassword').addEventListener('input', function() {
        checkPasswordStrength(this.value);
    });
    
    // Manipular envio do formulário
    document.getElementById('passwordForm').addEventListener('submit', function(e) {
        e.preventDefault();
        generatePasswords();
    });
}

// Gerar senhas
function generatePasswords() {
    const length = parseInt(document.getElementById('passwordLength').value);
    const count = parseInt(document.getElementById('passwordCount').value);
    const uppercase = document.getElementById('uppercase').checked;
    const lowercase = document.getElementById('lowercase').checked;
    const numbers = document.getElementById('numbers').checked;
    const symbols = document.getElementById('symbols').checked;
    const noSimilar = document.getElementById('noSimilar').checked;
    const noAmbiguous = document.getElementById('noAmbiguous').checked;
    const noRepeating = document.getElementById('noRepeating').checked;
    const customChars = document.getElementById('customChars').value;
    
    // Validar se pelo menos um tipo de caractere está selecionado
    if (!uppercase && !lowercase && !numbers && !symbols && !customChars) {
        showMessage(document.getElementById('passwordForm'), 'Selecione pelo menos um tipo de caractere.', 'error');
        return;
    }
    
    generatedPasswords = [];
    
    for (let i = 0; i < count; i++) {
        const password = generateSinglePassword({
            length,
            uppercase,
            lowercase,
            numbers,
            symbols,
            noSimilar,
            noAmbiguous,
            noRepeating,
            customChars
        });
        
        generatedPasswords.push(password);
    }
    
    displayPasswords();
    saveToPasswordHistory();
}

// Gerar uma única senha
function generateSinglePassword(options) {
    let charset = '';
    
    // Adicionar caracteres baseados nas opções
    if (options.uppercase) charset += 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    if (options.lowercase) charset += 'abcdefghijklmnopqrstuvwxyz';
    if (options.numbers) charset += '0123456789';
    if (options.symbols) charset += '!@#$%^&*()_+-=[]{}|;:,.<>?';
    if (options.customChars) charset += options.customChars;
    
    // Remover caracteres similares se solicitado
    if (options.noSimilar) {
        charset = charset.replace(/[l1I0O]/g, '');
    }
    
    // Remover caracteres ambíguos se solicitado
    if (options.noAmbiguous) {
        charset = charset.replace(/[{}[\]()/\\]/g, '');
    }
    
    if (charset.length === 0) {
        throw new Error('Nenhum caractere disponível com as configurações selecionadas.');
    }
    
    let password = '';
    const usedChars = new Set();
    
    for (let i = 0; i < options.length; i++) {
        let char;
        let attempts = 0;
        
        do {
            char = charset[Math.floor(Math.random() * charset.length)];
            attempts++;
            
            // Evitar loop infinito
            if (attempts > charset.length * 2) {
                break;
            }
        } while (options.noRepeating && usedChars.has(char));
        
        password += char;
        if (options.noRepeating) {
            usedChars.add(char);
        }
    }
    
    return password;
}

// Exibir senhas geradas
function displayPasswords() {
    const container = document.getElementById('passwordResults');
    const resultContainer = document.getElementById('resultContainer');
    
    let html = '<div class="password-list">';
    generatedPasswords.forEach((password, index) => {
        const strength = calculatePasswordStrength(password);
        const strengthClass = getStrengthClass(strength);
        const strengthLabel = getStrengthLabel(strength);
        
        html += `
            <div class="password-item">
                <div class="password-display">
                    <span class="password-text" id="password-${index}">${password}</span>
                    <button class="btn btn-secondary btn-sm" onclick="togglePasswordVisibility(${index})">
                        <i class="fas fa-eye"></i>
                    </button>
                    <button class="btn btn-primary btn-sm" onclick="copyPassword(${index})">
                        <i class="fas fa-copy"></i>
                    </button>
                </div>
                <div class="password-info">
                    <span class="strength-badge ${strengthClass}">${strengthLabel}</span>
                    <span class="password-length">${password.length} caracteres</span>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
    resultContainer.style.display = 'block';
    
    // Scroll para os resultados
    resultContainer.scrollIntoView({ behavior: 'smooth' });
}

// Alternar visibilidade da senha
function togglePasswordVisibility(index) {
    const passwordElement = document.getElementById(`password-${index}`);
    const button = passwordElement.nextElementSibling;
    const icon = button.querySelector('i');
    
    if (passwordElement.type === 'password' || passwordElement.style.webkitTextSecurity === 'disc') {
        passwordElement.style.webkitTextSecurity = 'none';
        icon.className = 'fas fa-eye-slash';
    } else {
        passwordElement.style.webkitTextSecurity = 'disc';
        icon.className = 'fas fa-eye';
    }
}

// Copiar senha individual
function copyPassword(index) {
    const password = generatedPasswords[index];
    copyToClipboard(password);
}

// Copiar todas as senhas
function copyAllPasswords() {
    const allPasswords = generatedPasswords.join('\n');
    copyToClipboard(allPasswords);
}

// Baixar lista de senhas
function downloadPasswords() {
    const content = generatedPasswords.join('\n');
    const blob = new Blob([content], { type: 'text/plain' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'senhas_geradas.txt';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
    
    showMessage(document.getElementById('resultContainer'), 'Arquivo baixado com sucesso!', 'success');
}

// Calcular força da senha
function calculatePasswordStrength(password) {
    let score = 0;
    
    // Comprimento
    if (password.length >= 8) score += 1;
    if (password.length >= 12) score += 1;
    if (password.length >= 16) score += 1;
    
    // Tipos de caracteres
    if (/[a-z]/.test(password)) score += 1;
    if (/[A-Z]/.test(password)) score += 1;
    if (/[0-9]/.test(password)) score += 1;
    if (/[^A-Za-z0-9]/.test(password)) score += 1;
    
    // Complexidade adicional
    if (password.length >= 8 && /[a-z]/.test(password) && /[A-Z]/.test(password) && /[0-9]/.test(password)) {
        score += 1;
    }
    
    return Math.min(score, 5);
}

// Obter classe CSS para força
function getStrengthClass(strength) {
    if (strength <= 1) return 'strength-very-weak';
    if (strength <= 2) return 'strength-weak';
    if (strength <= 3) return 'strength-medium';
    if (strength <= 4) return 'strength-strong';
    return 'strength-very-strong';
}

// Obter label para força
function getStrengthLabel(strength) {
    if (strength <= 1) return 'Muito Fraca';
    if (strength <= 2) return 'Fraca';
    if (strength <= 3) return 'Média';
    if (strength <= 4) return 'Forte';
    return 'Muito Forte';
}

// Verificar força da senha
function checkPasswordStrength(password) {
    const container = document.getElementById('strengthResult');
    
    if (!password) {
        container.innerHTML = '';
        return;
    }
    
    const strength = calculatePasswordStrength(password);
    const strengthClass = getStrengthClass(strength);
    const strengthLabel = getStrengthLabel(strength);
    
    const feedback = getPasswordFeedback(password);
    
    container.innerHTML = `
        <div class="strength-meter">
            <div class="strength-bar">
                <div class="strength-fill ${strengthClass}" style="width: ${(strength / 5) * 100}%"></div>
            </div>
            <div class="strength-info">
                <span class="strength-label ${strengthClass}">${strengthLabel}</span>
                <span class="strength-score">${strength}/5</span>
            </div>
        </div>
        <div class="password-feedback">
            ${feedback.map(item => `<div class="feedback-item ${item.valid ? 'valid' : 'invalid'}">
                <i class="fas fa-${item.valid ? 'check' : 'times'}"></i>
                ${item.message}
            </div>`).join('')}
        </div>
    `;
}

// Obter feedback da senha
function getPasswordFeedback(password) {
    const feedback = [];
    
    feedback.push({
        valid: password.length >= 8,
        message: 'Pelo menos 8 caracteres'
    });
    
    feedback.push({
        valid: /[a-z]/.test(password),
        message: 'Pelo menos uma letra minúscula'
    });
    
    feedback.push({
        valid: /[A-Z]/.test(password),
        message: 'Pelo menos uma letra maiúscula'
    });
    
    feedback.push({
        valid: /[0-9]/.test(password),
        message: 'Pelo menos um número'
    });
    
    feedback.push({
        valid: /[^A-Za-z0-9]/.test(password),
        message: 'Pelo menos um símbolo'
    });
    
    return feedback;
}

// Salvar no histórico
function saveToPasswordHistory() {
    const historyItem = {
        id: generateId(),
        passwords: [...generatedPasswords],
        settings: {
            length: document.getElementById('passwordLength').value,
            count: document.getElementById('passwordCount').value,
            uppercase: document.getElementById('uppercase').checked,
            lowercase: document.getElementById('lowercase').checked,
            numbers: document.getElementById('numbers').checked,
            symbols: document.getElementById('symbols').checked
        },
        date: new Date().toISOString()
    };
    
    passwordHistory.unshift(historyItem);
    
    // Manter apenas os últimos 10 itens
    if (passwordHistory.length > 10) {
        passwordHistory = passwordHistory.slice(0, 10);
    }
    
    saveToLocalStorage('passwordHistory', passwordHistory);
    updatePasswordHistoryDisplay();
}

// Carregar histórico de senhas
function loadPasswordHistory() {
    const history = loadFromLocalStorage('passwordHistory');
    if (history) {
        passwordHistory = history;
        updatePasswordHistoryDisplay();
    }
}

// Atualizar exibição do histórico
function updatePasswordHistoryDisplay() {
    const container = document.getElementById('passwordHistoryContainer');
    
    if (passwordHistory.length === 0) {
        container.innerHTML = '<p>Nenhuma senha gerada ainda.</p>';
        return;
    }
    
    let html = '<div class="password-history-list">';
    passwordHistory.forEach(item => {
        const date = new Date(item.date).toLocaleDateString('pt-BR');
        const settings = item.settings;
        
        html += `
            <div class="password-history-item">
                <div class="history-info">
                    <h4>Senhas Geradas - ${date}</h4>
                    <p><strong>Configurações:</strong> ${settings.length} chars, ${settings.count} senhas</p>
                    <p><strong>Tipos:</strong> ${getSettingsDescription(settings)}</p>
                    <div class="password-preview">
                        ${item.passwords.map(pwd => `<code>${pwd}</code>`).join(' ')}
                    </div>
                </div>
                <div class="history-actions">
                    <button class="btn btn-secondary" onclick="loadPasswordSettings('${item.id}')">
                        <i class="fas fa-cog"></i> Usar Configurações
                    </button>
                    <button class="btn btn-primary" onclick="copyHistoryPasswords('${item.id}')">
                        <i class="fas fa-copy"></i> Copiar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Obter descrição das configurações
function getSettingsDescription(settings) {
    const types = [];
    if (settings.uppercase) types.push('Maiúsculas');
    if (settings.lowercase) types.push('Minúsculas');
    if (settings.numbers) types.push('Números');
    if (settings.symbols) types.push('Símbolos');
    return types.join(', ');
}

// Carregar configurações do histórico
function loadPasswordSettings(historyId) {
    const item = passwordHistory.find(h => h.id === historyId);
    if (!item) return;
    
    const settings = item.settings;
    
    document.getElementById('passwordLength').value = settings.length;
    document.getElementById('passwordCount').value = settings.count;
    document.getElementById('uppercase').checked = settings.uppercase;
    document.getElementById('lowercase').checked = settings.lowercase;
    document.getElementById('numbers').checked = settings.numbers;
    document.getElementById('symbols').checked = settings.symbols;
    
    document.getElementById('lengthValue').textContent = settings.length + ' caracteres';
    
    // Scroll para o formulário
    document.getElementById('passwordForm').scrollIntoView({ behavior: 'smooth' });
    
    showMessage(document.getElementById('passwordForm'), 'Configurações carregadas! Clique em "Gerar Senhas" para usar.', 'success');
}

// Copiar senhas do histórico
function copyHistoryPasswords(historyId) {
    const item = passwordHistory.find(h => h.id === historyId);
    if (!item) return;
    
    const passwords = item.passwords.join('\n');
    copyToClipboard(passwords);
}

// Adicionar estilos CSS específicos
const style = document.createElement('style');
style.textContent = `
    .password-options {
        margin: 2rem 0;
        padding: 1.5rem;
        background: #f8f9fa;
        border-radius: 8px;
        border: 1px solid #e9ecef;
    }
    
    .password-options h3 {
        margin-bottom: 1rem;
        color: #333;
        font-size: 1.2rem;
    }
    
    .options-grid {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
        gap: 1rem;
    }
    
    .option-item {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        padding: 0.75rem;
        background: white;
        border: 1px solid #e9ecef;
        border-radius: 6px;
        cursor: pointer;
        transition: all 0.3s ease;
    }
    
    .option-item:hover {
        border-color: #667eea;
        background: #f8f9ff;
    }
    
    .option-item input[type="checkbox"] {
        margin: 0;
    }
    
    .option-text {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        font-weight: 500;
    }
    
    .option-text i {
        color: #667eea;
        width: 16px;
    }
    
    .password-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .password-item {
        background: #f8f9fa;
        border: 1px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
    }
    
    .password-display {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        margin-bottom: 0.5rem;
    }
    
    .password-text {
        flex: 1;
        font-family: 'Courier New', monospace;
        font-size: 1.1rem;
        font-weight: 600;
        padding: 0.5rem;
        background: white;
        border: 1px solid #e9ecef;
        border-radius: 4px;
        word-break: break-all;
    }
    
    .btn-sm {
        padding: 0.5rem 0.75rem;
        font-size: 0.9rem;
    }
    
    .password-info {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    
    .strength-badge {
        padding: 0.25rem 0.5rem;
        border-radius: 4px;
        font-size: 0.8rem;
        font-weight: 600;
    }
    
    .strength-very-weak {
        background: #f8d7da;
        color: #721c24;
    }
    
    .strength-weak {
        background: #fff3cd;
        color: #856404;
    }
    
    .strength-medium {
        background: #d1ecf1;
        color: #0c5460;
    }
    
    .strength-strong {
        background: #d4edda;
        color: #155724;
    }
    
    .strength-very-strong {
        background: #cce5ff;
        color: #004085;
    }
    
    .password-length {
        font-size: 0.9rem;
        color: #666;
    }
    
    .password-actions {
        display: flex;
        gap: 1rem;
        margin-top: 1rem;
        flex-wrap: wrap;
    }
    
    .strength-meter {
        margin: 1rem 0;
    }
    
    .strength-bar {
        width: 100%;
        height: 8px;
        background: #e9ecef;
        border-radius: 4px;
        overflow: hidden;
        margin-bottom: 0.5rem;
    }
    
    .strength-fill {
        height: 100%;
        transition: width 0.3s ease;
    }
    
    .strength-info {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    
    .strength-label {
        font-weight: 600;
    }
    
    .strength-score {
        font-size: 0.9rem;
        color: #666;
    }
    
    .password-feedback {
        margin-top: 1rem;
    }
    
    .feedback-item {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        margin-bottom: 0.5rem;
        font-size: 0.9rem;
    }
    
    .feedback-item.valid {
        color: #155724;
    }
    
    .feedback-item.invalid {
        color: #721c24;
    }
    
    .feedback-item i {
        width: 16px;
    }
    
    .password-history-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .password-history-item {
        background: #f8f9fa;
        border: 1px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
        display: flex;
        justify-content: space-between;
        align-items: flex-start;
        gap: 1rem;
    }
    
    .history-info {
        flex: 1;
    }
    
    .history-info h4 {
        margin-bottom: 0.5rem;
        color: #333;
    }
    
    .history-info p {
        margin-bottom: 0.5rem;
        color: #666;
        font-size: 0.9rem;
    }
    
    .password-preview {
        margin-top: 0.5rem;
    }
    
    .password-preview code {
        background: white;
        padding: 0.25rem 0.5rem;
        border-radius: 4px;
        font-size: 0.8rem;
        margin-right: 0.5rem;
        margin-bottom: 0.25rem;
        display: inline-block;
    }
    
    .history-actions {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
    }
    
    @media (max-width: 768px) {
        .options-grid {
            grid-template-columns: 1fr;
        }
        
        .password-display {
            flex-direction: column;
            align-items: stretch;
        }
        
        .password-info {
            flex-direction: column;
            align-items: flex-start;
            gap: 0.5rem;
        }
        
        .password-history-item {
            flex-direction: column;
        }
        
        .history-actions {
            flex-direction: row;
            width: 100%;
        }
        
        .password-actions {
            flex-direction: column;
        }
    }
`;
document.head.appendChild(style); 