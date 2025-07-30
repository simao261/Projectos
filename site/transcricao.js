// Variáveis globais
let currentTranscription = '';
let transcriptionHistory = [];

// Carregar histórico ao iniciar
document.addEventListener('DOMContentLoaded', function() {
    loadTranscriptionHistory();
});

// Função para simular transcrição (em um ambiente real, isso seria conectado a uma API)
function simulateTranscription(audioFile, language, includePunctuation, includeTimestamps) {
    return new Promise((resolve) => {
        const progressBar = document.querySelector('.progress-fill');
        const progressText = document.getElementById('progressText');
        let progress = 0;
        
        const interval = setInterval(() => {
            progress += Math.random() * 15;
            if (progress > 100) progress = 100;
            
            progressBar.style.width = progress + '%';
            
            if (progress < 30) {
                progressText.textContent = 'Analisando áudio...';
            } else if (progress < 60) {
                progressText.textContent = 'Convertendo para texto...';
            } else if (progress < 90) {
                progressText.textContent = 'Aplicando correções...';
            } else {
                progressText.textContent = 'Finalizando...';
            }
            
            if (progress >= 100) {
                clearInterval(interval);
                
                // Simular resultado de transcrição
                const mockTranscription = generateMockTranscription(audioFile.name, language, includePunctuation, includeTimestamps);
                resolve(mockTranscription);
            }
        }, 200);
    });
}

// Gerar transcrição simulada
function generateMockTranscription(fileName, language, includePunctuation, includeTimestamps) {
    const mockTexts = {
        'pt-BR': [
            'Olá, bem-vindo ao nosso sistema de transcrição de áudio. Esta é uma demonstração da funcionalidade de conversão de áudio para texto. O sistema está funcionando perfeitamente e pode processar diferentes tipos de arquivos de áudio.',
            'Esta é uma reunião importante sobre o projeto de desenvolvimento. Precisamos discutir os próximos passos e definir as responsabilidades de cada membro da equipe.',
            'A transcrição automática de áudio é uma tecnologia muito útil para profissionais que precisam converter gravações em texto de forma rápida e eficiente.'
        ],
        'en-US': [
            'Hello, welcome to our audio transcription system. This is a demonstration of the audio to text conversion functionality. The system is working perfectly and can process different types of audio files.',
            'This is an important meeting about the development project. We need to discuss the next steps and define the responsibilities of each team member.',
            'Automatic audio transcription is a very useful technology for professionals who need to convert recordings to text quickly and efficiently.'
        ]
    };
    
    const texts = mockTexts[language] || mockTexts['pt-BR'];
    let transcription = texts[Math.floor(Math.random() * texts.length)];
    
    if (includeTimestamps) {
        transcription = addTimestamps(transcription);
    }
    
    if (!includePunctuation) {
        transcription = transcription.replace(/[.,!?;:]/g, '');
    }
    
    return transcription;
}

// Adicionar timestamps simulados
function addTimestamps(text) {
    const sentences = text.split('. ');
    let result = '';
    let time = 0;
    
    sentences.forEach((sentence, index) => {
        const minutes = Math.floor(time / 60);
        const seconds = time % 60;
        const timestamp = `[${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}] `;
        result += timestamp + sentence + (index < sentences.length - 1 ? '. ' : '');
        time += Math.floor(Math.random() * 30) + 10; // Adicionar tempo aleatório
    });
    
    return result;
}

// Manipular envio do formulário
document.getElementById('transcriptionForm').addEventListener('submit', async function(e) {
    e.preventDefault();
    
    const audioFile = document.getElementById('audioFile').files[0];
    const language = document.getElementById('language').value;
    const includePunctuation = document.getElementById('punctuation').checked;
    const includeTimestamps = document.getElementById('timestamps').checked;
    
    if (!audioFile) {
        showMessage(document.getElementById('audioFile'), 'Por favor, selecione um arquivo de áudio.', 'error');
        return;
    }
    
    // Validar tipo de arquivo
    const allowedTypes = ['audio/mpeg', 'audio/wav', 'audio/mp4', 'audio/ogg', 'audio/webm'];
    if (!allowedTypes.includes(audioFile.type)) {
        showMessage(document.getElementById('audioFile'), 'Formato de arquivo não suportado. Use MP3, WAV, M4A ou OGG.', 'error');
        return;
    }
    
    // Mostrar progresso
    document.getElementById('progressContainer').style.display = 'block';
    document.getElementById('resultContainer').style.display = 'none';
    
    try {
        // Simular transcrição
        const transcription = await simulateTranscription(audioFile, language, includePunctuation, includeTimestamps);
        
        // Salvar resultado
        currentTranscription = transcription;
        
        // Mostrar resultado
        document.getElementById('transcriptionResult').textContent = transcription;
        document.getElementById('resultContainer').style.display = 'block';
        
        // Salvar no histórico
        saveTranscriptionToHistory({
            id: generateId(),
            fileName: audioFile.name,
            language: language,
            transcription: transcription,
            date: new Date().toISOString(),
            fileSize: audioFile.size
        });
        
        showMessage(document.getElementById('transcriptionForm'), 'Transcrição concluída com sucesso!', 'success');
        
    } catch (error) {
        showMessage(document.getElementById('transcriptionForm'), 'Erro ao processar transcrição. Tente novamente.', 'error');
    } finally {
        document.getElementById('progressContainer').style.display = 'none';
    }
});

// Copiar transcrição para área de transferência
function copyTranscription() {
    if (currentTranscription) {
        copyToClipboard(currentTranscription);
    }
}

// Baixar transcrição como arquivo TXT
function downloadTranscription() {
    if (!currentTranscription) return;
    
    const blob = new Blob([currentTranscription], { type: 'text/plain' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'transcricao.txt';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
    
    showMessage(document.getElementById('resultContainer'), 'Arquivo baixado com sucesso!', 'success');
}

// Salvar transcrição no histórico
function saveTranscriptionToHistory(transcriptionData) {
    transcriptionHistory.unshift(transcriptionData);
    
    // Manter apenas os últimos 10 itens
    if (transcriptionHistory.length > 10) {
        transcriptionHistory = transcriptionHistory.slice(0, 10);
    }
    
    saveToLocalStorage('transcriptionHistory', transcriptionHistory);
    updateHistoryDisplay();
}

// Carregar histórico de transcrições
function loadTranscriptionHistory() {
    const history = loadFromLocalStorage('transcriptionHistory');
    if (history) {
        transcriptionHistory = history;
        updateHistoryDisplay();
    }
}

// Atualizar exibição do histórico
function updateHistoryDisplay() {
    const container = document.getElementById('historyContainer');
    
    if (transcriptionHistory.length === 0) {
        container.innerHTML = '<p>Nenhuma transcrição realizada ainda.</p>';
        return;
    }
    
    let html = '<div class="history-list">';
    transcriptionHistory.forEach(item => {
        const date = new Date(item.date).toLocaleDateString('pt-BR');
        const fileSize = (item.fileSize / 1024 / 1024).toFixed(2);
        
        html += `
            <div class="history-item">
                <div class="history-info">
                    <h4>${item.fileName}</h4>
                    <p><strong>Idioma:</strong> ${item.language} | <strong>Data:</strong> ${date} | <strong>Tamanho:</strong> ${fileSize} MB</p>
                    <p class="transcription-preview">${item.transcription.substring(0, 100)}${item.transcription.length > 100 ? '...' : ''}</p>
                </div>
                <div class="history-actions">
                    <button class="btn btn-secondary" onclick="loadTranscription('${item.id}')">
                        <i class="fas fa-eye"></i> Ver
                    </button>
                    <button class="btn btn-primary" onclick="copyHistoryTranscription('${item.id}')">
                        <i class="fas fa-copy"></i> Copiar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Carregar transcrição do histórico
function loadTranscription(id) {
    const item = transcriptionHistory.find(t => t.id === id);
    if (item) {
        currentTranscription = item.transcription;
        document.getElementById('transcriptionResult').textContent = item.transcription;
        document.getElementById('resultContainer').style.display = 'block';
        
        // Scroll para o resultado
        document.getElementById('resultContainer').scrollIntoView({ behavior: 'smooth' });
    }
}

// Copiar transcrição do histórico
function copyHistoryTranscription(id) {
    const item = transcriptionHistory.find(t => t.id === id);
    if (item) {
        copyToClipboard(item.transcription);
    }
}

// Adicionar estilos CSS para o histórico
const style = document.createElement('style');
style.textContent = `
    .history-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .history-item {
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
    
    .transcription-preview {
        background: white;
        padding: 0.5rem;
        border-radius: 4px;
        border-left: 3px solid #667eea;
        font-style: italic;
    }
    
    .history-actions {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
    }
    
    .progress-bar {
        width: 100%;
        height: 20px;
        background: #e9ecef;
        border-radius: 10px;
        overflow: hidden;
        margin-bottom: 1rem;
    }
    
    .progress-fill {
        height: 100%;
        background: linear-gradient(90deg, #667eea, #764ba2);
        width: 0%;
        transition: width 0.3s ease;
    }
    
    .result-actions {
        display: flex;
        gap: 1rem;
        margin-top: 1rem;
        flex-wrap: wrap;
    }
    
    @media (max-width: 768px) {
        .history-item {
            flex-direction: column;
        }
        
        .history-actions {
            flex-direction: row;
            width: 100%;
        }
        
        .result-actions {
            flex-direction: column;
        }
    }
`;
document.head.appendChild(style); 