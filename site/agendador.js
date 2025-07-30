// Variáveis globais
let scheduledEmails = [];
let emailHistory = [];

// Carregar dados ao iniciar
document.addEventListener('DOMContentLoaded', function() {
    loadScheduledEmails();
    loadEmailHistory();
    setMinDate();
    startEmailScheduler();
});

// Definir data mínima como hoje
function setMinDate() {
    const today = new Date().toISOString().split('T')[0];
    document.getElementById('scheduleDate').min = today;
}

// Manipular envio do formulário
document.getElementById('emailForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    const emailData = {
        id: generateId(),
        recipientEmail: document.getElementById('recipientEmail').value,
        recipientName: document.getElementById('recipientName').value,
        subject: document.getElementById('emailSubject').value,
        body: document.getElementById('emailBody').value,
        scheduleDate: document.getElementById('scheduleDate').value,
        scheduleTime: document.getElementById('scheduleTime').value,
        sendCopy: document.getElementById('sendCopy').checked,
        priority: document.getElementById('priority').value,
        status: 'scheduled',
        createdAt: new Date().toISOString()
    };
    
    // Validar data e hora
    const scheduledDateTime = new Date(`${emailData.scheduleDate}T${emailData.scheduleTime}`);
    const now = new Date();
    
    if (scheduledDateTime <= now) {
        showMessage(document.getElementById('emailForm'), 'A data e hora de envio devem ser futuras.', 'error');
        return;
    }
    
    // Adicionar email agendado
    scheduledEmails.push(emailData);
    saveScheduledEmails();
    updateScheduledEmailsDisplay();
    
    // Limpar formulário
    document.getElementById('emailForm').reset();
    setMinDate();
    
    showMessage(document.getElementById('emailForm'), 'Email agendado com sucesso!', 'success');
});

// Salvar emails agendados
function saveScheduledEmails() {
    saveToLocalStorage('scheduledEmails', scheduledEmails);
}

// Carregar emails agendados
function loadScheduledEmails() {
    const emails = loadFromLocalStorage('scheduledEmails');
    if (emails) {
        scheduledEmails = emails;
        updateScheduledEmailsDisplay();
    }
}

// Atualizar exibição dos emails agendados
function updateScheduledEmailsDisplay() {
    const container = document.getElementById('scheduledEmailsContainer');
    
    if (scheduledEmails.length === 0) {
        container.innerHTML = '<p>Nenhum email agendado ainda.</p>';
        return;
    }
    
    // Filtrar apenas emails agendados (não enviados)
    const activeEmails = scheduledEmails.filter(email => email.status === 'scheduled');
    
    if (activeEmails.length === 0) {
        container.innerHTML = '<p>Nenhum email agendado ainda.</p>';
        return;
    }
    
    let html = '<div class="email-list">';
    activeEmails.forEach(email => {
        const scheduledDate = new Date(`${email.scheduleDate}T${email.scheduleTime}`);
        const formattedDate = formatDate(scheduledDate);
        const priorityClass = getPriorityClass(email.priority);
        
        html += `
            <div class="email-item ${priorityClass}">
                <div class="email-info">
                    <div class="email-header">
                        <h4>${email.subject}</h4>
                        <span class="priority-badge ${priorityClass}">${getPriorityLabel(email.priority)}</span>
                    </div>
                    <p><strong>Para:</strong> ${email.recipientName} (${email.recipientEmail})</p>
                    <p><strong>Agendado para:</strong> ${formattedDate}</p>
                    <p class="email-preview">${email.body.substring(0, 100)}${email.body.length > 100 ? '...' : ''}</p>
                </div>
                <div class="email-actions">
                    <button class="btn btn-secondary" onclick="editEmail('${email.id}')">
                        <i class="fas fa-edit"></i> Editar
                    </button>
                    <button class="btn btn-primary" onclick="sendEmailNow('${email.id}')">
                        <i class="fas fa-paper-plane"></i> Enviar Agora
                    </button>
                    <button class="btn btn-danger" onclick="cancelEmail('${email.id}')">
                        <i class="fas fa-times"></i> Cancelar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Obter classe CSS para prioridade
function getPriorityClass(priority) {
    switch (priority) {
        case 'urgent': return 'priority-urgent';
        case 'high': return 'priority-high';
        default: return 'priority-normal';
    }
}

// Obter label para prioridade
function getPriorityLabel(priority) {
    switch (priority) {
        case 'urgent': return 'Urgente';
        case 'high': return 'Alta';
        default: return 'Normal';
    }
}

// Editar email agendado
function editEmail(emailId) {
    const email = scheduledEmails.find(e => e.id === emailId);
    if (!email) return;
    
    // Preencher formulário com dados do email
    document.getElementById('recipientEmail').value = email.recipientEmail;
    document.getElementById('recipientName').value = email.recipientName;
    document.getElementById('emailSubject').value = email.subject;
    document.getElementById('emailBody').value = email.body;
    document.getElementById('scheduleDate').value = email.scheduleDate;
    document.getElementById('scheduleTime').value = email.scheduleTime;
    document.getElementById('sendCopy').checked = email.sendCopy;
    document.getElementById('priority').value = email.priority;
    
    // Remover email antigo
    scheduledEmails = scheduledEmails.filter(e => e.id !== emailId);
    saveScheduledEmails();
    updateScheduledEmailsDisplay();
    
    // Scroll para o formulário
    document.getElementById('emailForm').scrollIntoView({ behavior: 'smooth' });
    
    showMessage(document.getElementById('emailForm'), 'Email carregado para edição. Clique em "Agendar Email" para salvar as alterações.', 'success');
}

// Enviar email agora
function sendEmailNow(emailId) {
    const email = scheduledEmails.find(e => e.id === emailId);
    if (!email) return;
    
    // Simular envio
    simulateEmailSending(email);
    
    // Marcar como enviado
    email.status = 'sent';
    email.sentAt = new Date().toISOString();
    
    // Mover para histórico
    emailHistory.unshift(email);
    scheduledEmails = scheduledEmails.filter(e => e.id !== emailId);
    
    saveScheduledEmails();
    saveEmailHistory();
    updateScheduledEmailsDisplay();
    updateEmailHistoryDisplay();
    
    showMessage(document.getElementById('scheduledEmailsContainer'), 'Email enviado com sucesso!', 'success');
}

// Cancelar email agendado
function cancelEmail(emailId) {
    if (confirm('Tem certeza que deseja cancelar este email?')) {
        scheduledEmails = scheduledEmails.filter(e => e.id !== emailId);
        saveScheduledEmails();
        updateScheduledEmailsDisplay();
        
        showMessage(document.getElementById('scheduledEmailsContainer'), 'Email cancelado com sucesso!', 'success');
    }
}

// Simular envio de email
function simulateEmailSending(email) {
    console.log('Simulando envio de email:', {
        to: email.recipientEmail,
        subject: email.subject,
        body: email.body,
        scheduledFor: `${email.scheduleDate}T${email.scheduleTime}`
    });
    
    // Em um ambiente real, aqui seria feita a integração com um serviço de email
    // como SendGrid, Mailgun, ou similar
}

// Salvar histórico de emails
function saveEmailHistory() {
    saveToLocalStorage('emailHistory', emailHistory);
}

// Carregar histórico de emails
function loadEmailHistory() {
    const history = loadFromLocalStorage('emailHistory');
    if (history) {
        emailHistory = history;
        updateEmailHistoryDisplay();
    }
}

// Atualizar exibição do histórico
function updateEmailHistoryDisplay() {
    const container = document.getElementById('emailHistoryContainer');
    
    if (emailHistory.length === 0) {
        container.innerHTML = '<p>Nenhum email enviado ainda.</p>';
        return;
    }
    
    let html = '<div class="email-history-list">';
    emailHistory.forEach(email => {
        const sentDate = new Date(email.sentAt);
        const formattedDate = formatDate(sentDate);
        const priorityClass = getPriorityClass(email.priority);
        
        html += `
            <div class="email-history-item ${priorityClass}">
                <div class="email-info">
                    <div class="email-header">
                        <h4>${email.subject}</h4>
                        <span class="priority-badge ${priorityClass}">${getPriorityLabel(email.priority)}</span>
                    </div>
                    <p><strong>Para:</strong> ${email.recipientName} (${email.recipientEmail})</p>
                    <p><strong>Enviado em:</strong> ${formattedDate}</p>
                    <p class="email-preview">${email.body.substring(0, 100)}${email.body.length > 100 ? '...' : ''}</p>
                </div>
                <div class="email-actions">
                    <button class="btn btn-secondary" onclick="viewEmailDetails('${email.id}')">
                        <i class="fas fa-eye"></i> Ver Detalhes
                    </button>
                    <button class="btn btn-primary" onclick="resendEmail('${email.id}')">
                        <i class="fas fa-redo"></i> Reenviar
                    </button>
                </div>
            </div>
        `;
    });
    html += '</div>';
    
    container.innerHTML = html;
}

// Ver detalhes do email
function viewEmailDetails(emailId) {
    const email = emailHistory.find(e => e.id === emailId);
    if (!email) return;
    
    const details = `
Assunto: ${email.subject}
Para: ${email.recipientName} (${email.recipientEmail})
Enviado em: ${formatDate(new Date(email.sentAt))}
Prioridade: ${getPriorityLabel(email.priority)}

Mensagem:
${email.body}
    `;
    
    alert(details);
}

// Reenviar email
function resendEmail(emailId) {
    const email = emailHistory.find(e => e.id === emailId);
    if (!email) return;
    
    if (confirm('Deseja reenviar este email?')) {
        simulateEmailSending(email);
        showMessage(document.getElementById('emailHistoryContainer'), 'Email reenviado com sucesso!', 'success');
    }
}

// Iniciar agendador de emails
function startEmailScheduler() {
    // Verificar emails agendados a cada minuto
    setInterval(() => {
        const now = new Date();
        
        scheduledEmails.forEach(email => {
            if (email.status === 'scheduled') {
                const scheduledDateTime = new Date(`${email.scheduleDate}T${email.scheduleTime}`);
                
                if (scheduledDateTime <= now) {
                    // Enviar email automaticamente
                    simulateEmailSending(email);
                    
                    // Marcar como enviado
                    email.status = 'sent';
                    email.sentAt = new Date().toISOString();
                    
                    // Mover para histórico
                    emailHistory.unshift(email);
                }
            }
        });
        
        // Remover emails enviados da lista de agendados
        scheduledEmails = scheduledEmails.filter(email => email.status === 'scheduled');
        
        // Salvar alterações
        saveScheduledEmails();
        saveEmailHistory();
        updateScheduledEmailsDisplay();
        updateEmailHistoryDisplay();
    }, 60000); // Verificar a cada minuto
}

// Adicionar estilos CSS específicos
const style = document.createElement('style');
style.textContent = `
    .form-row {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 1rem;
    }
    
    .email-list,
    .email-history-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    
    .email-item,
    .email-history-item {
        background: #f8f9fa;
        border: 1px solid #e9ecef;
        border-radius: 8px;
        padding: 1rem;
        display: flex;
        justify-content: space-between;
        align-items: flex-start;
        gap: 1rem;
    }
    
    .email-info {
        flex: 1;
    }
    
    .email-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 0.5rem;
    }
    
    .email-header h4 {
        margin: 0;
        color: #333;
    }
    
    .priority-badge {
        padding: 0.25rem 0.5rem;
        border-radius: 4px;
        font-size: 0.8rem;
        font-weight: 600;
    }
    
    .priority-normal {
        background: #e9ecef;
        color: #495057;
    }
    
    .priority-high {
        background: #fff3cd;
        color: #856404;
    }
    
    .priority-urgent {
        background: #f8d7da;
        color: #721c24;
    }
    
    .email-item.priority-high,
    .email-history-item.priority-high {
        border-left: 4px solid #ffc107;
    }
    
    .email-item.priority-urgent,
    .email-history-item.priority-urgent {
        border-left: 4px solid #dc3545;
    }
    
    .email-info p {
        margin-bottom: 0.5rem;
        color: #666;
        font-size: 0.9rem;
    }
    
    .email-preview {
        background: white;
        padding: 0.5rem;
        border-radius: 4px;
        border-left: 3px solid #667eea;
        font-style: italic;
        margin-top: 0.5rem;
    }
    
    .email-actions {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
    }
    
    .btn-danger {
        background: #dc3545;
        color: white;
    }
    
    .btn-danger:hover {
        background: #c82333;
    }
    
    @media (max-width: 768px) {
        .form-row {
            grid-template-columns: 1fr;
        }
        
        .email-item,
        .email-history-item {
            flex-direction: column;
        }
        
        .email-actions {
            flex-direction: row;
            width: 100%;
        }
        
        .email-header {
            flex-direction: column;
            align-items: flex-start;
            gap: 0.5rem;
        }
    }
`;
document.head.appendChild(style); 