# Real → Digital — Jogos da Vida Real Digitais

Site estático, profissional e responsivo que transforma jogos tradicionais em experiências digitais. Primeiro jogo: Amarelinha (Jogo da Macaca).

## Como usar

- Abra `index.html` em um navegador moderno; ou
- Sirva a pasta com um servidor estático (HTTP) e acesse no navegador.

Exemplo com Python (opcional):

```bash
cd real2digital
python3 -m http.server 8000
# depois acesse http://localhost:8000
```

## Estrutura
- `index.html`: SPA simples com rotas via hash.
- `styles/main.css`: estilo global e do jogo.
- `scripts/app.js`: roteador e telas iniciais.
- `games/hopscotch.js`: lógica da Amarelinha.

## Próximos jogos
- Pular corda
- Quatro cantos
- Pião

Contribuições e ideias são bem-vindas.