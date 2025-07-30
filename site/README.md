# TechTools Pro

Um site profissional com ferramentas úteis para suas necessidades diárias.

## 🚀 Funcionalidades

### 1. Transcrição de Áudio
- **Conversão de áudio para texto** com suporte a múltiplos formatos
- **Idiomas suportados**: Português, Inglês, Espanhol, Francês, Alemão
- **Opções personalizáveis**: pontuação, timestamps
- **Histórico de transcrições** com visualização e cópia
- **Download de resultados** em formato TXT

### 2. Agendador de Emails
- **Agendamento automático** de emails para envio futuro
- **Configurações avançadas**: prioridade, cópia para remetente
- **Gerenciamento completo**: editar, cancelar, enviar agora
- **Histórico de envios** com detalhes completos
- **Sistema de prioridades**: Normal, Alta, Urgente

### 3. Gerador de Senhas
- **Senhas seguras** com regras customizáveis
- **Tipos de caracteres**: maiúsculas, minúsculas, números, símbolos
- **Regras especiais**: excluir similares, evitar repetições
- **Verificador de força** em tempo real
- **Histórico de senhas** geradas
- **Caracteres personalizados** opcionais

### 4. Calculadora de Criptografia
- **8 algoritmos clássicos**: César, Vigenère, Base64, Hexadecimal, Binário, Morse, Rail Fence, Atbash
- **Criptografar e descriptografar** mensagens
- **Opções personalizáveis**: preservar maiúsculas, espaços
- **Histórico de operações** com visualização
- **Informações detalhadas** sobre cada algoritmo

### 5. Conversor de Formatos
- **Conversão de texto**: Base64, Hexadecimal, Binário, URL, HTML
- **Conversão de números**: Decimal, Binário, Octal, Hexadecimal
- **Conversão de tempo**: Segundos, Minutos, Horas, Dias, etc.
- **Conversor de cores**: Hexadecimal, RGB, HSL, Nomes
- **Conversor de unidades**: Comprimento, Peso, Área, Volume, Temperatura, Velocidade

## 🛠️ Tecnologias Utilizadas

- **HTML5** - Estrutura semântica
- **CSS3** - Design responsivo e moderno
- **JavaScript (ES6+)** - Funcionalidades interativas
- **Font Awesome** - Ícones profissionais
- **LocalStorage** - Persistência de dados

## 📁 Estrutura do Projeto

```
site/
├── index.html              # Página inicial
├── transcricao.html        # Página de transcrição
├── agendador.html          # Página do agendador
├── senhas.html            # Página do gerador de senhas
├── criptografia.html       # Página de criptografia
├── conversor.html          # Página do conversor
├── styles.css             # Estilos CSS principais
├── script.js              # JavaScript comum
├── transcricao.js         # JavaScript da transcrição
├── agendador.js           # JavaScript do agendador
├── senhas.js              # JavaScript do gerador de senhas
├── criptografia.js        # JavaScript da criptografia
├── conversor.js           # JavaScript do conversor
└── README.md              # Documentação
```

## 🎨 Design e UX

### Características do Design
- **Design responsivo** que funciona em todos os dispositivos
- **Interface moderna** com gradientes e animações suaves
- **Navegação intuitiva** com menu mobile-friendly
- **Feedback visual** para todas as ações do usuário
- **Cores profissionais** com esquema consistente
- **Sistema de temas** claro/escuro com persistência
- **Dashboard com estatísticas** animadas

### Experiência do Usuário
- **Carregamento rápido** e otimizado
- **Feedback imediato** para todas as ações
- **Validação em tempo real** de formulários
- **Histórico persistente** usando localStorage
- **Animações suaves** para melhor engajamento

## 🔧 Como Usar

### Transcrição de Áudio
1. Acesse a página de transcrição
2. Selecione um arquivo de áudio (MP3, WAV, M4A, OGG)
3. Escolha o idioma e opções desejadas
4. Clique em "Iniciar Transcrição"
5. Aguarde o processamento e visualize o resultado
6. Copie ou baixe o texto transcrito

### Agendador de Emails
1. Acesse a página do agendador
2. Preencha os dados do destinatário
3. Escreva o assunto e mensagem
4. Defina data e horário de envio
5. Configure prioridade e opções adicionais
6. Clique em "Agendar Email"
7. Gerencie seus emails agendados

### Gerador de Senhas
1. Acesse a página do gerador
2. Configure o comprimento e quantidade
3. Selecione os tipos de caracteres desejados
4. Aplique regras especiais se necessário
5. Adicione caracteres personalizados (opcional)
6. Clique em "Gerar Senhas"
7. Copie ou baixe as senhas geradas

### Calculadora de Criptografia
1. Acesse a página de criptografia
2. Escolha o algoritmo desejado
3. Selecione modo (criptografar/descriptografar)
4. Digite a chave (se necessário)
5. Insira o texto para processar
6. Configure opções de preservação
7. Clique em "Processar"

### Conversor de Formatos
1. Acesse a página do conversor
2. Escolha o tipo de conversão (Texto, Números, Tempo, Cores, Unidades)
3. Preencha os dados de entrada
4. Selecione os formatos de origem e destino
5. Clique em "Converter"
6. Visualize e copie o resultado

## 📱 Responsividade

O site é totalmente responsivo e funciona perfeitamente em:
- **Desktop** (1200px+)
- **Tablet** (768px - 1199px)
- **Mobile** (até 767px)

### Adaptações Mobile
- Menu hambúrguer para navegação
- Layout em coluna única
- Botões maiores para touch
- Formulários otimizados para mobile

## 💾 Armazenamento Local

O site utiliza localStorage para persistir dados:
- **Histórico de transcrições** (últimas 10)
- **Emails agendados** e histórico de envios
- **Senhas geradas** e configurações salvas

## 🔒 Segurança

### Transcrição
- Processamento local (simulado)
- Validação de tipos de arquivo
- Limpeza automática de dados

### Agendador
- Validação de emails
- Verificação de datas futuras
- Simulação de envio seguro

### Gerador de Senhas
- Geração client-side
- Nenhum dado enviado para servidor
- Verificação de força local

## 🚀 Como Executar

1. **Clone ou baixe** os arquivos do projeto
2. **Abra o arquivo** `index.html` em um navegador
3. **Navegue** pelas diferentes ferramentas
4. **Teste** todas as funcionalidades

### Requisitos
- Navegador moderno (Chrome, Firefox, Safari, Edge)
- JavaScript habilitado
- Conexão com internet (para ícones Font Awesome)

## 🎯 Funcionalidades Avançadas

### Transcrição
- **Simulação realista** de processamento
- **Progress bar** animada
- **Múltiplos idiomas** com textos de exemplo
- **Timestamps** opcionais

### Agendador
- **Sistema de prioridades** visual
- **Verificação automática** de emails agendados
- **Edição inline** de emails
- **Reenvio** de emails do histórico

### Gerador de Senhas
- **Verificador de força** em tempo real
- **Feedback visual** detalhado
- **Regras customizáveis** avançadas
- **Histórico com configurações**

### Calculadora de Criptografia
- **8 algoritmos clássicos** implementados
- **Interface intuitiva** com validação
- **Histórico detalhado** de operações
- **Informações educativas** sobre cada algoritmo

### Conversor de Formatos
- **5 tipos de conversão** diferentes
- **Interface com abas** organizada
- **Validação em tempo real** de entradas
- **Visualização de cores** em tempo real

## 🔮 Próximas Melhorias

- [x] Sistema de temas claro/escuro
- [x] Dashboard com estatísticas
- [x] Calculadora de criptografia
- [x] Conversor de formatos
- [ ] Integração com APIs reais de transcrição
- [ ] Sistema de login e sincronização
- [ ] Mais idiomas para transcrição
- [ ] Exportação em mais formatos (PDF, CSV)
- [ ] Integração com serviços de email reais
- [ ] Notificações push para emails agendados
- [ ] Mais algoritmos de criptografia
- [ ] Conversor de moedas em tempo real

## 📞 Suporte

Para dúvidas ou sugestões:
- **Email**: contato@techtoolspro.com
- **Telefone**: +55 (11) 99999-9999

## 📄 Licença

Este projeto é de código aberto e está disponível sob a licença MIT.

---

**TechTools Pro** - Ferramentas profissionais para suas necessidades diárias. 