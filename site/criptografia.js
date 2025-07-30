// Variáveis globais
let cryptoHistory = [];
let currentResult = {};

// Carregar dados ao iniciar
document.addEventListener('DOMContentLoaded', function() {
    loadCryptoHistory();
    setupCryptoEventListeners();
});

// Configurar event listeners
function setupCryptoEventListeners() {
    // Manipular mudança de algoritmo
    document.getElementById('cryptoAlgorithm').addEventListener('change', function() {
        updateKeyPlaceholder();
    });
    
    // Manipular envio do formulário
    document.getElementById('cryptoForm').addEventListener('submit', function(e) {
        e.preventDefault();
        processCrypto();
    });
}

// Atualizar placeholder da chave baseado no algoritmo
function updateKeyPlaceholder() {
    const algorithm = document.getElementById('cryptoAlgorithm').value;
    const keyInput = document.getElementById('cryptoKey');
    
    const placeholders = {
        'caesar': 'Digite o número de deslocamento (ex: 3)',
        'vigenere': 'Digite a palavra-chave (ex: SECRETO)',
        'base64': 'Não necessário',
        'hex': 'Não necessário',
        'binary': 'Não necessário',
        'morse': 'Não necessário',
        'railfence': 'Digite o número de linhas (ex: 3)',
        'atbash': 'Não necessário'
    };
    
    keyInput.placeholder = placeholders[algorithm];
    
    // Ocultar campo de chave para algoritmos que não precisam
    const keyContainer = document.getElementById('keyContainer');
    if (['base64', 'hex', 'binary', 'morse', 'atbash'].includes(algorithm)) {
        keyContainer.style.display = 'none';
    } else {
        keyContainer.style.display = 'block';
    }
}

// Processar criptografia
function processCrypto() {
    const algorithm = document.getElementById('cryptoAlgorithm').value;
    const mode = document.getElementById('cryptoMode').value;
    const key = document.getElementById('cryptoKey').value;
    const text = document.getElementById('cryptoText').value;
    const preserveCase = document.getElementById('preserveCase').checked;
    const preserveSpaces = document.getElementById('preserveSpaces').checked;
    
    if (!text.trim()) {
        showMessage(document.getElementById('cryptoText'), 'Digite um texto para processar.', 'error');
        return;
    }
    
    // Validar chave para algoritmos que precisam
    if (['caesar', 'vigenere', 'railfence'].includes(algorithm) && !key.trim()) {
        showMessage(document.getElementById('cryptoKey'), 'Digite uma chave válida.', 'error');
        return;
    }
    
    let result;
    try {
        if (mode === 'encrypt') {
            result = encryptText(text, algorithm, key, preserveCase, preserveSpaces);
        } else {
            result = decryptText(text, algorithm, key, preserveCase, preserveSpaces);
        }
        
        displayCryptoResult(text, result);
        saveToCryptoHistory({
            algorithm,
            mode,
            key,
            originalText: text,
            processedText: result,
            preserveCase,
            preserveSpaces
        });
        
    } catch (error) {
        showMessage(document.getElementById('cryptoForm'), 'Erro ao processar: ' + error.message, 'error');
    }
}

// Criptografar texto
function encryptText(text, algorithm, key, preserveCase, preserveSpaces) {
    switch (algorithm) {
        case 'caesar':
            return caesarCipher(text, parseInt(key), true, preserveCase, preserveSpaces);
        case 'vigenere':
            return vigenereCipher(text, key, true, preserveCase, preserveSpaces);
        case 'base64':
            return btoa(text);
        case 'hex':
            return textToHex(text);
        case 'binary':
            return textToBinary(text);
        case 'morse':
            return textToMorse(text);
        case 'railfence':
            return railFenceCipher(text, parseInt(key), true);
        case 'atbash':
            return atbashCipher(text, preserveCase, preserveSpaces);
        default:
            throw new Error('Algoritmo não suportado');
    }
}

// Descriptografar texto
function decryptText(text, algorithm, key, preserveCase, preserveSpaces) {
    switch (algorithm) {
        case 'caesar':
            return caesarCipher(text, parseInt(key), false, preserveCase, preserveSpaces);
        case 'vigenere':
            return vigenereCipher(text, key, false, preserveCase, preserveSpaces);
        case 'base64':
            return atob(text);
        case 'hex':
            return hexToText(text);
        case 'binary':
            return binaryToText(text);
        case 'morse':
            return morseToText(text);
        case 'railfence':
            return railFenceCipher(text, parseInt(key), false);
        case 'atbash':
            return atbashCipher(text, preserveCase, preserveSpaces);
        default:
            throw new Error('Algoritmo não suportado');
    }
}

// Cifra de César
function caesarCipher(text, shift, encrypt, preserveCase, preserveSpaces) {
    const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const direction = encrypt ? 1 : -1;
    
    return text.split('').map(char => {
        if (!preserveSpaces && char === ' ') return '';
        if (!preserveSpaces && /[^a-zA-Z]/.test(char)) return '';
        
        const isUpperCase = char === char.toUpperCase();
        const charUpper = char.toUpperCase();
        const index = alphabet.indexOf(charUpper);
        
        if (index === -1) return char;
        
        let newIndex = (index + (direction * shift)) % 26;
        if (newIndex < 0) newIndex += 26;
        
        let result = alphabet[newIndex];
        return preserveCase && !isUpperCase ? result.toLowerCase() : result;
    }).join('');
}

// Cifra de Vigenère
function vigenereCipher(text, key, encrypt, preserveCase, preserveSpaces) {
    const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const keyUpper = key.toUpperCase();
    const direction = encrypt ? 1 : -1;
    
    let keyIndex = 0;
    
    return text.split('').map(char => {
        if (!preserveSpaces && char === ' ') return '';
        if (!preserveSpaces && /[^a-zA-Z]/.test(char)) return '';
        
        const isUpperCase = char === char.toUpperCase();
        const charUpper = char.toUpperCase();
        const index = alphabet.indexOf(charUpper);
        
        if (index === -1) return char;
        
        const keyChar = keyUpper[keyIndex % keyUpper.length];
        const keyShift = alphabet.indexOf(keyChar);
        
        let newIndex = (index + (direction * keyShift)) % 26;
        if (newIndex < 0) newIndex += 26;
        
        keyIndex++;
        let result = alphabet[newIndex];
        return preserveCase && !isUpperCase ? result.toLowerCase() : result;
    }).join('');
}

// Conversão para Hexadecimal
function textToHex(text) {
    return text.split('').map(char => {
        return char.charCodeAt(0).toString(16).padStart(2, '0');
    }).join(' ');
}

// Conversão de Hexadecimal para texto
function hexToText(hex) {
    return hex.split(' ').map(hexChar => {
        return String.fromCharCode(parseInt(hexChar, 16));
    }).join('');
}

// Conversão para Binário
function textToBinary(text) {
    return text.split('').map(char => {
        return char.charCodeAt(0).toString(2).padStart(8, '0');
    }).join(' ');
}

// Conversão de Binário para texto
function binaryToText(binary) {
    return binary.split(' ').map(binChar => {
        return String.fromCharCode(parseInt(binChar, 2));
    }).join('');
}

// Conversão para Morse
function textToMorse(text) {
    const morseCode = {
        'A': '.-', 'B': '-...', 'C': '-.-.', 'D': '-..', 'E': '.', 'F': '..-.',
        'G': '--.', 'H': '....', 'I': '..', 'J': '.---', 'K': '-.-', 'L': '.-..',
        'M': '--', 'N': '-.', 'O': '---', 'P': '.--.', 'Q': '--.-', 'R': '.-.',
        'S': '...', 'T': '-', 'U': '..-', 'V': '...-', 'W': '.--', 'X': '-..-',
        'Y': '-.--', 'Z': '--..', '0': '-----', '1': '.----', '2': '..---',
        '3': '...--', '4': '....-', '5': '.....', '6': '-....', '7': '--...',
        '8': '---..', '9': '----.'
    };
    
    return text.toUpperCase().split('').map(char => {
        return morseCode[char] || char;
    }).join(' ');
}

// Conversão de Morse para texto
function morseToText(morse) {
    const morseCode = {
        '.-': 'A', '-...': 'B', '-.-.': 'C', '-..': 'D', '.': 'E', '..-.': 'F',
        '--.': 'G', '....': 'H', '..': 'I', '.---': 'J', '-.-': 'K', '.-..': 'L',
        '--': 'M', '-.': 'N', '---': 'O', '.--.': 'P', '--.-': 'Q', '.-.': 'R',
        '...': 'S', '-': 'T', '..-': 'U', '...-': 'V', '.--': 'W', '-..-': 'X',
        '-.--': 'Y', '--..': 'Z', '-----': '0', '.----': '1', '..---': '2',
        '...--': '3', '....-': '4', '.....': '5', '-....': '6', '--...': '7',
        '---..': '8', '----.': '9'
    };
    
    return morse.split(' ').map(morseChar => {
        return morseCode[morseChar] || morseChar;
    }).join('');
}

// Rail Fence Cipher
function railFenceCipher(text, rails, encrypt) {
    if (encrypt) {
        const matrix = Array(rails).fill().map(() => []);
        let row = 0;
        let direction = 1;
        
        for (let i = 0; i < text.length; i++) {
            matrix[row].push(text[i]);
            row += direction;
            
            if (row === rails - 1) direction = -1;
            if (row === 0) direction = 1;
        }
        
        return matrix.map(row => row.join('')).join('');
    } else {
        // Decrypt Rail Fence
        const matrix = Array(rails).fill().map(() => []);
        let index = 0;
        let row = 0;
        let direction = 1;
        
        // Calculate positions
        for (let i = 0; i < text.length; i++) {
            matrix[row].push(i);
            row += direction;
            if (row === rails - 1) direction = -1;
            if (row === 0) direction = 1;
        }
        
        // Fill matrix with characters
        let charIndex = 0;
        for (let r = 0; r < rails; r++) {
            for (let c = 0; c < matrix[r].length; c++) {
                matrix[r][c] = text[charIndex++];
            }
        }
        
        // Read in original order
        const result = [];
        row = 0;
        direction = 1;
        
        for (let i = 0; i < text.length; i++) {
            result.push(matrix[row].shift());
            row += direction;
            if (row === rails - 1) direction = -1;
            if (row === 0) direction = 1;
        }
        
        return result.join('');
    }
}

// Cifra Atbash
function atbashCipher(text, preserveCase, preserveSpaces) {
    const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    
    return text.split('').map(char => {
        if (!preserveSpaces && char === ' ') return '';
        if (!preserveSpaces && /[^a-zA-Z]/.test(char)) return '';
        
        const isUpperCase = char === char.toUpperCase();
        const charUpper = char.toUpperCase();
        const index = alphabet.indexOf(charUpper);
        
        if (index === -1) return char;
        
        const newIndex = 25 - index;
        let result = alphabet[newIndex];
        return preserveCase && !isUpperCase ? result.toLowerCase() : result;
    }).join('');
}

// Exibir resultado
function displayCryptoResult(original, processed) {
    document.getElementById('originalText').textContent = original;
    document.getElementById('processedText').textContent = processed;
    document.getElementById('resultContainer').style.display = 'block';
    
    currentResult = { original, processed };
    
    // Scroll para o resultado
    document.getElementById('resultContainer').scrollIntoView({ behavior: 'smooth' });
}

// Copiar resultado
function copyResult() {
    const processed = document.getElementById('processedText').textContent;
    copyToClipboard(processed);
}

// Baixar resultado
function downloadResult() {
    const processed = document.getElementById('processedText').textContent;
    const blob = new Blob([processed], { type: 'text/plain' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'criptografia_resultado.txt';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
    
    showMessage(document.getElementById('resultContainer'), 'Arquivo baixado com sucesso!', 'success');
}

// Trocar textos
function swapTexts() {
    const original = document.getElementById('originalText').textContent;
    const processed = document.getElementById('processedText').textContent;
    
    document.getElementById('originalText').textContent = processed;
    document.getElementById('processedText').textContent = original;
    
    // Trocar também no formulário
    document.getElementById('cryptoText').value = processed;
    
    showMessage(document.getElementById('resultContainer'), 'Textos trocados!', 'success');
}

// Salvar no histórico
function saveToCryptoHistory(cryptoData) {
    const historyItem = {
        id: generateId(),
        ...cryptoData,
        date: new Date().toISOString()
    };
    
    cryptoHistory.unshift(historyItem);
    
    // Manter apenas os últimos 10 itens
    if (cryptoHistory.length > 10) {
        cryptoHistory = cryptoHistory.slice(0, 10);
    }
    
    saveToLocalStorage('cryptoHistory', cryptoHistory);
    updateCryptoHistoryDisplay();
}

// Carregar histórico
function loadCryptoHistory() {
    const history = loadFromLocalStorage('cryptoHistory');
    if (history) {
        cryptoHistory = history;
        updateCryptoHistoryDisplay();
    }
}

// Atualizar exibição do histórico
function updateCryptoHistoryDisplay() {
    const container = document.getElementById('cryptoHistoryContainer');
    
    if (cryptoHistory.length === 0) {
        container.innerHTML = '<p>Nenhuma operação realizada ainda.</p>';
        return;
    }
    
    let html = '<div class="crypto-history-list">';
    cryptoHistory.forEach(item => {
        const date = new Date(item.date).toLocaleDateString('pt-BR');
        const modeLabel = item.mode === 'encrypt' ? 'Criptografado' : 'Descriptografado';
        
        html += `
            <div class="crypto-history-item">
                <div class="history-info">
                    <h4>${getAlgorithmLabel(item.algorithm)} - ${modeLabel}</h4>
                    <p><strong>Data:</strong> ${date} | <strong>Chave:</strong> ${item.key || 'N/A'}</p>
                    <div class="crypto-preview">
                        <div><strong>Original:</strong> <code>${item.originalText.substring(0, 50)}${item.originalText.length > 50 ? '...' : ''}</code></div>
                        <div><strong>Processado:</strong> <code>${item.processedText.substring(0, 50)}${item.processedText.length > 50 ? '...' : ''}</code></div>
                    </div>
                </div>
                <div class="history-actions">
                    <button class="btn btn-secondary" onclick="loadCryptoSettings('${item.id}')">
                        <i class="fas fa-cog"></i> Usar Configurações
                    </button>
                    <button class="btn btn-primary" onclick="copyHistoryCrypto('${item.id}')">
                        <i class="fas fa-copy"></i> Copiar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Obter label do algoritmo
function getAlgorithmLabel(algorithm) {
    const labels = {
        'caesar': 'Cifra de César',
        'vigenere': 'Cifra de Vigenère',
        'base64': 'Base64',
        'hex': 'Hexadecimal',
        'binary': 'Binário',
        'morse': 'Código Morse',
        'railfence': 'Rail Fence',
        'atbash': 'Atbash'
    };
    return labels[algorithm] || algorithm;
}

// Carregar configurações do histórico
function loadCryptoSettings(historyId) {
    const item = cryptoHistory.find(h => h.id === historyId);
    if (!item) return;
    
    document.getElementById('cryptoAlgorithm').value = item.algorithm;
    document.getElementById('cryptoMode').value = item.mode;
    document.getElementById('cryptoKey').value = item.key;
    document.getElementById('cryptoText').value = item.originalText;
    document.getElementById('preserveCase').checked = item.preserveCase;
    document.getElementById('preserveSpaces').checked = item.preserveSpaces;
    
    updateKeyPlaceholder();
    
    // Scroll para o formulário
    document.getElementById('cryptoForm').scrollIntoView({ behavior: 'smooth' });
    
    showMessage(document.getElementById('cryptoForm'), 'Configurações carregadas! Clique em "Processar" para usar.', 'success');
}

// Copiar do histórico
function copyHistoryCrypto(historyId) {
    const item = cryptoHistory.find(h => h.id === historyId);
    if (!item) return;
    
    copyToClipboard(item.processedText);
}

// Adicionar estilos CSS específicos
const style = document.createElement('style');
style.textContent = `
    .crypto-result {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 2rem;
        margin-bottom: 2rem;
    }
    
    .result-section h3 {
        margin-bottom: 1rem;
        color: #333;
        font-size: 1.2rem;
    }
    
    .result-text {
        background: #f8f9fa;
        border: 2px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
        min-height: 100px;
        font-family: 'Courier New', monospace;
        white-space: pre-wrap;
        word-break: break-all;
    }
    
    .crypto-actions {
        display: flex;
        gap: 1rem;
        flex-wrap: wrap;
    }
    
    .btn-success {
        background: #28a745;
        color: white;
    }
    
    .btn-success:hover {
        background: #218838;
    }
    
    .crypto-history-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .crypto-history-item {
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
    
    .crypto-preview {
        margin-top: 0.5rem;
    }
    
    .crypto-preview div {
        margin-bottom: 0.25rem;
    }
    
    .crypto-preview code {
        background: white;
        padding: 0.25rem 0.5rem;
        border-radius: 4px;
        font-size: 0.8rem;
    }
    
    .history-actions {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
    }
    
    .algorithm-info {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
        gap: 1rem;
    }
    
    .algorithm-card {
        background: #f8f9fa;
        border: 1px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
        transition: all 0.3s ease;
    }
    
    .algorithm-card:hover {
        border-color: #667eea;
        box-shadow: 0 2px 8px rgba(102, 126, 234, 0.1);
    }
    
    .algorithm-card h3 {
        margin-bottom: 0.5rem;
        color: #333;
        font-size: 1.1rem;
        display: flex;
        align-items: center;
        gap: 0.5rem;
    }
    
    .algorithm-card h3 i {
        color: #667eea;
    }
    
    .algorithm-card p {
        color: #666;
        line-height: 1.5;
        font-size: 0.9rem;
    }
    
    @media (max-width: 768px) {
        .crypto-result {
            grid-template-columns: 1fr;
            gap: 1rem;
        }
        
        .crypto-history-item {
            flex-direction: column;
        }
        
        .history-actions {
            flex-direction: row;
            width: 100%;
        }
        
        .crypto-actions {
            flex-direction: column;
        }
        
        .algorithm-info {
            grid-template-columns: 1fr;
        }
    }
`;
document.head.appendChild(style); 