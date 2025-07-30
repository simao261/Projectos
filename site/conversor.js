// Variáveis globais
let converterHistory = [];
let currentConverterResult = {};

// Carregar dados ao iniciar
document.addEventListener('DOMContentLoaded', function() {
    loadConverterHistory();
    setupConverterEventListeners();
    setupUnitConverter();
});

// Configurar event listeners
function setupConverterEventListeners() {
    // Tabs do conversor
    document.querySelectorAll('.tab-btn').forEach(btn => {
        btn.addEventListener('click', function() {
            const tab = this.getAttribute('data-tab');
            switchTab(tab);
        });
    });
    
    // Formulários
    document.getElementById('textConverterForm').addEventListener('submit', function(e) {
        e.preventDefault();
        convertText();
    });
    
    document.getElementById('numberConverterForm').addEventListener('submit', function(e) {
        e.preventDefault();
        convertNumber();
    });
    
    document.getElementById('timeConverterForm').addEventListener('submit', function(e) {
        e.preventDefault();
        convertTime();
    });
    
    document.getElementById('colorConverterForm').addEventListener('submit', function(e) {
        e.preventDefault();
        convertColor();
    });
    
    document.getElementById('unitConverterForm').addEventListener('submit', function(e) {
        e.preventDefault();
        convertUnit();
    });
    
    // Event listeners para mudanças em tempo real
    document.getElementById('colorInput').addEventListener('input', function() {
        updateColorPreview(this.value);
    });
    
    document.getElementById('unitCategory').addEventListener('change', function() {
        updateUnitOptions();
    });
}

// Trocar entre abas
function switchTab(tabName) {
    // Remover classe active de todas as abas e painéis
    document.querySelectorAll('.tab-btn').forEach(btn => btn.classList.remove('active'));
    document.querySelectorAll('.converter-panel').forEach(panel => panel.classList.remove('active'));
    
    // Adicionar classe active à aba e painel selecionados
    document.querySelector(`[data-tab="${tabName}"]`).classList.add('active');
    document.getElementById(`${tabName}-panel`).classList.add('active');
}

// Conversor de Texto
function convertText() {
    const input = document.getElementById('textInput').value;
    const fromFormat = document.getElementById('textFromFormat').value;
    const toFormat = document.getElementById('textToFormat').value;
    
    if (!input.trim()) {
        showMessage(document.getElementById('textInput'), 'Digite um texto para converter.', 'error');
        return;
    }
    
    let result;
    try {
        // Primeiro converter para texto normal
        let normalText = convertFromFormat(input, fromFormat);
        // Depois converter para o formato de destino
        result = convertToFormat(normalText, toFormat);
        
        displayConverterResult(input, result);
        saveToConverterHistory({
            type: 'text',
            fromFormat,
            toFormat,
            input,
            output: result
        });
        
    } catch (error) {
        showMessage(document.getElementById('textConverterForm'), 'Erro na conversão: ' + error.message, 'error');
    }
}

// Converter de formato para texto normal
function convertFromFormat(text, format) {
    switch (format) {
        case 'text':
            return text;
        case 'base64':
            return atob(text);
        case 'hex':
            return hexToText(text);
        case 'binary':
            return binaryToText(text);
        case 'url':
            return decodeURIComponent(text);
        case 'html':
            return decodeHTMLEntities(text);
        default:
            throw new Error('Formato de origem não suportado');
    }
}

// Converter texto normal para formato
function convertToFormat(text, format) {
    switch (format) {
        case 'text':
            return text;
        case 'base64':
            return btoa(text);
        case 'hex':
            return textToHex(text);
        case 'binary':
            return textToBinary(text);
        case 'url':
            return encodeURIComponent(text);
        case 'html':
            return encodeHTMLEntities(text);
        default:
            throw new Error('Formato de destino não suportado');
    }
}

// Conversor de Números
function convertNumber() {
    const input = document.getElementById('numberInput').value;
    const fromBase = parseInt(document.getElementById('numberFromBase').value);
    const toBase = parseInt(document.getElementById('numberToBase').value);
    
    if (!input.trim()) {
        showMessage(document.getElementById('numberInput'), 'Digite um número para converter.', 'error');
        return;
    }
    
    try {
        const decimal = parseInt(input, fromBase);
        if (isNaN(decimal)) {
            throw new Error('Número inválido para a base especificada');
        }
        
        const result = decimal.toString(toBase).toUpperCase();
        
        displayConverterResult(input, result);
        saveToConverterHistory({
            type: 'number',
            fromBase,
            toBase,
            input,
            output: result
        });
        
    } catch (error) {
        showMessage(document.getElementById('numberConverterForm'), 'Erro na conversão: ' + error.message, 'error');
    }
}

// Conversor de Tempo
function convertTime() {
    const input = parseFloat(document.getElementById('timeInput').value);
    const fromUnit = document.getElementById('timeFromUnit').value;
    const toUnit = document.getElementById('timeToUnit').value;
    
    if (isNaN(input)) {
        showMessage(document.getElementById('timeInput'), 'Digite um valor válido.', 'error');
        return;
    }
    
    try {
        const seconds = convertToSeconds(input, fromUnit);
        const result = convertFromSeconds(seconds, toUnit);
        
        displayConverterResult(`${input} ${fromUnit}`, `${result} ${toUnit}`);
        saveToConverterHistory({
            type: 'time',
            fromUnit,
            toUnit,
            input: `${input} ${fromUnit}`,
            output: `${result} ${toUnit}`
        });
        
    } catch (error) {
        showMessage(document.getElementById('timeConverterForm'), 'Erro na conversão: ' + error.message, 'error');
    }
}

// Converter para segundos
function convertToSeconds(value, unit) {
    const multipliers = {
        'seconds': 1,
        'minutes': 60,
        'hours': 3600,
        'days': 86400,
        'weeks': 604800,
        'months': 2592000, // Aproximado
        'years': 31536000 // Aproximado
    };
    
    return value * multipliers[unit];
}

// Converter de segundos
function convertFromSeconds(seconds, unit) {
    const divisors = {
        'seconds': 1,
        'minutes': 60,
        'hours': 3600,
        'days': 86400,
        'weeks': 604800,
        'months': 2592000,
        'years': 31536000
    };
    
    return (seconds / divisors[unit]).toFixed(6);
}

// Conversor de Cores
function convertColor() {
    const input = document.getElementById('colorInput').value;
    const fromFormat = document.getElementById('colorFromFormat').value;
    const toFormat = document.getElementById('colorToFormat').value;
    
    if (!input.trim()) {
        showMessage(document.getElementById('colorInput'), 'Digite uma cor válida.', 'error');
        return;
    }
    
    try {
        const rgb = parseColor(input, fromFormat);
        const result = formatColor(rgb, toFormat);
        
        displayConverterResult(input, result);
        updateColorPreview(input);
        
        saveToConverterHistory({
            type: 'color',
            fromFormat,
            toFormat,
            input,
            output: result
        });
        
    } catch (error) {
        showMessage(document.getElementById('colorConverterForm'), 'Erro na conversão: ' + error.message, 'error');
    }
}

// Parsear cor para RGB
function parseColor(color, format) {
    switch (format) {
        case 'hex':
            return hexToRgb(color);
        case 'rgb':
            return parseRgb(color);
        case 'hsl':
            return hslToRgb(color);
        case 'name':
            return nameToRgb(color);
        default:
            throw new Error('Formato de cor não suportado');
    }
}

// Formatar cor
function formatColor(rgb, format) {
    switch (format) {
        case 'hex':
            return rgbToHex(rgb);
        case 'rgb':
            return `rgb(${rgb.r}, ${rgb.g}, ${rgb.b})`;
        case 'hsl':
            return rgbToHsl(rgb);
        case 'name':
            return rgbToName(rgb);
        default:
            throw new Error('Formato de destino não suportado');
    }
}

// Conversões de cor
function hexToRgb(hex) {
    const result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    if (!result) throw new Error('Formato hexadecimal inválido');
    return {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    };
}

function parseRgb(rgb) {
    const match = rgb.match(/rgb\((\d+),\s*(\d+),\s*(\d+)\)/);
    if (!match) throw new Error('Formato RGB inválido');
    return {
        r: parseInt(match[1]),
        g: parseInt(match[2]),
        b: parseInt(match[3])
    };
}

function rgbToHex(rgb) {
    return '#' + [rgb.r, rgb.g, rgb.b].map(x => {
        const hex = x.toString(16);
        return hex.length === 1 ? '0' + hex : hex;
    }).join('');
}

// Atualizar preview de cor
function updateColorPreview(colorInput) {
    const swatch = document.getElementById('colorSwatch');
    const text = document.getElementById('colorPreviewText');
    
    try {
        const rgb = parseColor(colorInput, 'hex');
        const hex = rgbToHex(rgb);
        swatch.style.backgroundColor = hex;
        text.textContent = hex;
    } catch (error) {
        swatch.style.backgroundColor = '#ccc';
        text.textContent = 'Cor inválida';
    }
}

// Conversor de Unidades
function convertUnit() {
    const input = parseFloat(document.getElementById('unitInput').value);
    const category = document.getElementById('unitCategory').value;
    const fromUnit = document.getElementById('unitFrom').value;
    const toUnit = document.getElementById('unitTo').value;
    
    if (isNaN(input)) {
        showMessage(document.getElementById('unitInput'), 'Digite um valor válido.', 'error');
        return;
    }
    
    try {
        const result = convertUnitValue(input, fromUnit, toUnit, category);
        
        displayConverterResult(`${input} ${fromUnit}`, `${result} ${toUnit}`);
        saveToConverterHistory({
            type: 'unit',
            category,
            fromUnit,
            toUnit,
            input: `${input} ${fromUnit}`,
            output: `${result} ${toUnit}`
        });
        
    } catch (error) {
        showMessage(document.getElementById('unitConverterForm'), 'Erro na conversão: ' + error.message, 'error');
    }
}

// Configurar conversor de unidades
function setupUnitConverter() {
    const categorySelect = document.getElementById('unitCategory');
    const fromSelect = document.getElementById('unitFrom');
    const toSelect = document.getElementById('unitTo');
    
    const units = {
        length: ['metros', 'quilômetros', 'centímetros', 'milímetros', 'polegadas', 'pés', 'jardas', 'milhas'],
        weight: ['gramas', 'quilogramas', 'miligramas', 'toneladas', 'libras', 'onças'],
        area: ['metros quadrados', 'quilômetros quadrados', 'centímetros quadrados', 'acres', 'hectares'],
        volume: ['litros', 'mililitros', 'metros cúbicos', 'galões', 'pintas'],
        temperature: ['celsius', 'fahrenheit', 'kelvin'],
        speed: ['km/h', 'm/s', 'mph', 'knots']
    };
    
    categorySelect.addEventListener('change', function() {
        const selectedCategory = this.value;
        const categoryUnits = units[selectedCategory] || [];
        
        // Limpar e preencher opções
        fromSelect.innerHTML = '';
        toSelect.innerHTML = '';
        
        categoryUnits.forEach(unit => {
            fromSelect.add(new Option(unit, unit));
            toSelect.add(new Option(unit, unit));
        });
        
        // Definir valores padrão diferentes
        if (categoryUnits.length > 1) {
            toSelect.value = categoryUnits[1];
        }
    });
    
    // Inicializar com primeira categoria
    categorySelect.dispatchEvent(new Event('change'));
}

// Converter valor de unidade
function convertUnitValue(value, fromUnit, toUnit, category) {
    // Implementação simplificada - em um projeto real, teria tabelas de conversão completas
    const conversions = {
        length: {
            'metros': 1,
            'quilômetros': 1000,
            'centímetros': 0.01,
            'polegadas': 0.0254,
            'pés': 0.3048
        },
        weight: {
            'gramas': 1,
            'quilogramas': 1000,
            'miligramas': 0.001,
            'libras': 453.592
        },
        temperature: {
            'celsius': 'celsius',
            'fahrenheit': 'fahrenheit',
            'kelvin': 'kelvin'
        }
    };
    
    const categoryConversions = conversions[category];
    if (!categoryConversions) {
        return value; // Retorna o mesmo valor se não houver conversão específica
    }
    
    if (category === 'temperature') {
        return convertTemperature(value, fromUnit, toUnit);
    }
    
    // Converter para unidade base e depois para unidade de destino
    const baseValue = value * (categoryConversions[fromUnit] || 1);
    const result = baseValue / (categoryConversions[toUnit] || 1);
    
    return result.toFixed(6);
}

// Converter temperatura
function convertTemperature(value, fromUnit, toUnit) {
    let celsius;
    
    // Converter para Celsius
    switch (fromUnit) {
        case 'celsius':
            celsius = value;
            break;
        case 'fahrenheit':
            celsius = (value - 32) * 5/9;
            break;
        case 'kelvin':
            celsius = value - 273.15;
            break;
        default:
            celsius = value;
    }
    
    // Converter de Celsius para unidade de destino
    switch (toUnit) {
        case 'celsius':
            return celsius;
        case 'fahrenheit':
            return (celsius * 9/5) + 32;
        case 'kelvin':
            return celsius + 273.15;
        default:
            return celsius;
    }
}

// Exibir resultado
function displayConverterResult(input, output) {
    document.getElementById('converterInput').textContent = input;
    document.getElementById('converterOutput').textContent = output;
    document.getElementById('converterResult').style.display = 'block';
    
    currentConverterResult = { input, output };
    
    // Scroll para o resultado
    document.getElementById('converterResult').scrollIntoView({ behavior: 'smooth' });
}

// Copiar resultado
function copyConverterResult() {
    const output = document.getElementById('converterOutput').textContent;
    copyToClipboard(output);
}

// Trocar valores
function swapConverterValues() {
    const input = document.getElementById('converterInput').textContent;
    const output = document.getElementById('converterOutput').textContent;
    
    document.getElementById('converterInput').textContent = output;
    document.getElementById('converterOutput').textContent = input;
    
    showMessage(document.getElementById('converterResult'), 'Valores trocados!', 'success');
}

// Salvar no histórico
function saveToConverterHistory(converterData) {
    const historyItem = {
        id: generateId(),
        ...converterData,
        date: new Date().toISOString()
    };
    
    converterHistory.unshift(historyItem);
    
    // Manter apenas os últimos 10 itens
    if (converterHistory.length > 10) {
        converterHistory = converterHistory.slice(0, 10);
    }
    
    saveToLocalStorage('converterHistory', converterHistory);
    updateConverterHistoryDisplay();
}

// Carregar histórico
function loadConverterHistory() {
    const history = loadFromLocalStorage('converterHistory');
    if (history) {
        converterHistory = history;
        updateConverterHistoryDisplay();
    }
}

// Atualizar exibição do histórico
function updateConverterHistoryDisplay() {
    const container = document.getElementById('converterHistoryContainer');
    
    if (converterHistory.length === 0) {
        container.innerHTML = '<p>Nenhuma conversão realizada ainda.</p>';
        return;
    }
    
    let html = '<div class="converter-history-list">';
    converterHistory.forEach(item => {
        const date = new Date(item.date).toLocaleDateString('pt-BR');
        const typeLabel = getConverterTypeLabel(item.type);
        
        html += `
            <div class="converter-history-item">
                <div class="history-info">
                    <h4>${typeLabel} - ${date}</h4>
                    <p><strong>De:</strong> ${item.input} | <strong>Para:</strong> ${item.output}</p>
                    <div class="converter-preview">
                        <div><strong>Entrada:</strong> <code>${item.input}</code></div>
                        <div><strong>Saída:</strong> <code>${item.output}</code></div>
                    </div>
                </div>
                <div class="history-actions">
                    <button class="btn btn-secondary" onclick="loadConverterSettings('${item.id}')">
                        <i class="fas fa-cog"></i> Usar Configurações
                    </button>
                    <button class="btn btn-primary" onclick="copyHistoryConverter('${item.id}')">
                        <i class="fas fa-copy"></i> Copiar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Obter label do tipo de conversor
function getConverterTypeLabel(type) {
    const labels = {
        'text': 'Conversor de Texto',
        'number': 'Conversor de Números',
        'time': 'Conversor de Tempo',
        'color': 'Conversor de Cores',
        'unit': 'Conversor de Unidades'
    };
    return labels[type] || type;
}

// Carregar configurações do histórico
function loadConverterSettings(historyId) {
    const item = converterHistory.find(h => h.id === historyId);
    if (!item) return;
    
    // Trocar para a aba correta
    switchTab(item.type);
    
    // Preencher formulário baseado no tipo
    switch (item.type) {
        case 'text':
            document.getElementById('textInput').value = item.input;
            document.getElementById('textFromFormat').value = item.fromFormat;
            document.getElementById('textToFormat').value = item.toFormat;
            break;
        case 'number':
            document.getElementById('numberInput').value = item.input;
            document.getElementById('numberFromBase').value = item.fromBase;
            document.getElementById('numberToBase').value = item.toBase;
            break;
        case 'time':
            const timeValue = parseFloat(item.input.split(' ')[0]);
            document.getElementById('timeInput').value = timeValue;
            document.getElementById('timeFromUnit').value = item.fromUnit;
            document.getElementById('timeToUnit').value = item.toUnit;
            break;
        case 'color':
            document.getElementById('colorInput').value = item.input;
            document.getElementById('colorFromFormat').value = item.fromFormat;
            document.getElementById('colorToFormat').value = item.toFormat;
            updateColorPreview(item.input);
            break;
        case 'unit':
            const unitValue = parseFloat(item.input.split(' ')[0]);
            document.getElementById('unitInput').value = unitValue;
            document.getElementById('unitCategory').value = item.category;
            // Atualizar opções de unidade
            document.getElementById('unitCategory').dispatchEvent(new Event('change'));
            setTimeout(() => {
                document.getElementById('unitFrom').value = item.fromUnit;
                document.getElementById('unitTo').value = item.toUnit;
            }, 100);
            break;
    }
    
    // Scroll para o formulário
    document.querySelector('.converter-panel.active').scrollIntoView({ behavior: 'smooth' });
    
    showMessage(document.querySelector('.converter-panel.active'), 'Configurações carregadas! Clique em "Converter" para usar.', 'success');
}

// Copiar do histórico
function copyHistoryConverter(historyId) {
    const item = converterHistory.find(h => h.id === historyId);
    if (!item) return;
    
    copyToClipboard(item.output);
}

// Funções auxiliares para conversão de texto
function textToHex(text) {
    return text.split('').map(char => {
        return char.charCodeAt(0).toString(16).padStart(2, '0');
    }).join(' ');
}

function hexToText(hex) {
    return hex.split(' ').map(hexChar => {
        return String.fromCharCode(parseInt(hexChar, 16));
    }).join('');
}

function textToBinary(text) {
    return text.split('').map(char => {
        return char.charCodeAt(0).toString(2).padStart(8, '0');
    }).join(' ');
}

function binaryToText(binary) {
    return binary.split(' ').map(binChar => {
        return String.fromCharCode(parseInt(binChar, 2));
    }).join('');
}

function decodeHTMLEntities(text) {
    const textarea = document.createElement('textarea');
    textarea.innerHTML = text;
    return textarea.value;
}

function encodeHTMLEntities(text) {
    return text.replace(/[&<>"']/g, function(match) {
        const entities = {
            '&': '&amp;',
            '<': '&lt;',
            '>': '&gt;',
            '"': '&quot;',
            "'": '&#39;'
        };
        return entities[match];
    });
}

// Funções auxiliares para cores
function hslToRgb(hsl) {
    // Implementação simplificada
    return { r: 0, g: 0, b: 0 };
}

function rgbToHsl(rgb) {
    // Implementação simplificada
    return `hsl(0, 0%, 0%)`;
}

function nameToRgb(name) {
    // Implementação simplificada
    return { r: 0, g: 0, b: 0 };
}

function rgbToName(rgb) {
    // Implementação simplificada
    return 'black';
}

// Adicionar estilos CSS específicos
const style = document.createElement('style');
style.textContent = `
    .converter-tabs {
        display: flex;
        gap: 0.5rem;
        margin-bottom: 2rem;
        flex-wrap: wrap;
    }
    
    .tab-btn {
        padding: 0.75rem 1.5rem;
        background: #f8f9fa;
        border: 1px solid #e9ecef;
        border-radius: 8px;
        cursor: pointer;
        transition: all 0.3s ease;
        font-weight: 500;
    }
    
    .tab-btn:hover {
        background: #e9ecef;
    }
    
    .tab-btn.active {
        background: #667eea;
        color: white;
        border-color: #667eea;
    }
    
    .converter-panel {
        display: none;
    }
    
    .converter-panel.active {
        display: block;
    }
    
    .converter-result {
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
    
    .result-display {
        background: #f8f9fa;
        border: 2px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
        min-height: 100px;
        font-family: 'Courier New', monospace;
        white-space: pre-wrap;
        word-break: break-all;
    }
    
    .converter-actions {
        display: flex;
        gap: 1rem;
        flex-wrap: wrap;
    }
    
    .color-preview {
        display: flex;
        align-items: center;
        gap: 1rem;
        margin: 1rem 0;
        padding: 1rem;
        background: #f8f9fa;
        border-radius: 8px;
    }
    
    .color-swatch {
        width: 50px;
        height: 50px;
        border-radius: 8px;
        border: 2px solid #e9ecef;
    }
    
    .converter-history-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .converter-history-item {
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
    
    .converter-preview {
        margin-top: 0.5rem;
    }
    
    .converter-preview div {
        margin-bottom: 0.25rem;
    }
    
    .converter-preview code {
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
    
    [data-theme="dark"] .tab-btn {
        background: var(--bg-tertiary);
        border-color: var(--border-color);
        color: var(--text-primary);
    }
    
    [data-theme="dark"] .tab-btn:hover {
        background: var(--bg-secondary);
    }
    
    [data-theme="dark"] .tab-btn.active {
        background: #667eea;
        color: white;
    }
    
    [data-theme="dark"] .result-display {
        background: var(--bg-tertiary);
        border-color: var(--border-color);
        color: var(--text-primary);
    }
    
    [data-theme="dark"] .color-preview {
        background: var(--bg-tertiary);
    }
    
    [data-theme="dark"] .converter-history-item {
        background: var(--bg-secondary);
        border-color: var(--border-color);
    }
    
    @media (max-width: 768px) {
        .converter-tabs {
            flex-direction: column;
        }
        
        .converter-result {
            grid-template-columns: 1fr;
            gap: 1rem;
        }
        
        .converter-history-item {
            flex-direction: column;
        }
        
        .history-actions {
            flex-direction: row;
            width: 100%;
        }
        
        .converter-actions {
            flex-direction: column;
        }
    }
`;
document.head.appendChild(style); 