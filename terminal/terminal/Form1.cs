using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terminal
{
    public partial class FormTerminal : Form
    {

        Queue<string> hackerMensagens = new Queue<string>();
        Timer hackerTimer = new Timer();

     

        public FormTerminal()
        {
            InitializeComponent();
        }

        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // evita beep do sistema
                e.Handled = true;           // garante que a tecla foi tratada

                string comando = txtEntrada.Text.Trim();
                ExecutarComando(comando);
                txtEntrada.Clear();
            }
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            txtSaida.Text = "🖥️ Terminal Simulado\nDigite 'help' para ver comandos disponíveis.\n";
            txtEntrada.Focus(); // <-- foca logo na entrada

            hackerTimer.Interval = 100;
            hackerTimer.Tick += HackerTimer_Tick;
        }

        private void ExecutarComando(string comando)
        {
            txtSaida.AppendText($"\r\n> {comando}");

            string[] partes = comando.Split(new[] { ' ' }, 2);
            string baseComando = partes[0].ToLower();
            string argumento = partes.Length > 1 ? partes[1] : "";

            switch (baseComando)
            {
                case "help":
                    txtSaida.AppendText("\r\nComandos disponíveis:");
                    txtSaida.AppendText("\r\n  help         - Lista os comandos");
                    txtSaida.AppendText("\r\n  about        - Sobre o criador");
                    txtSaida.AppendText("\r\n  versao       - Versão do terminal");
                    txtSaida.AppendText("\r\n  hora         - Hora atual");
                    txtSaida.AppendText("\r\n  data         - Data atual");
                    txtSaida.AppendText("\r\n  echo [texto] - Repete o que escreveste");
                    txtSaida.AppendText("\r\n  cls          - Limpa o terminal");
                    txtSaida.AppendText("\r\n  sair         - Fecha o terminal");
                    txtSaida.AppendText("\r\n  hacker       - Ativa o modo hacker");
                    break;

                case "about":
                    txtSaida.AppendText("\r\nTerminal Simulado v1.0 — Criado por Simão 🧠");
                    break;

                case "versao":
                    txtSaida.AppendText("\r\nVersão: 0.2 Beta");
                    break;

                case "hora":
                    txtSaida.AppendText("\r\nHora atual: " + DateTime.Now.ToString("HH:mm:ss"));
                    break;

                case "data":
                    txtSaida.AppendText("\r\nData atual: " + DateTime.Now.ToString("dd/MM/yyyy"));
                    break;

                case "cls":
                    txtSaida.Clear();
                    break;

                case "sair":
                    Application.Exit();
                    break;

                case "echo":
                    if (string.IsNullOrWhiteSpace(argumento))
                        txtSaida.AppendText("\r\n⚠️ Usa: echo [texto]");
                    else
                        txtSaida.AppendText("\r\n" + argumento);
                    break;

                case "hacker":
                    PrepararModoHacker();
                    break;

                default:
                    txtSaida.AppendText($"\r\nComando inválido: \"{comando}\"");
                    break;
            }
        }

        private void PrepararModoHacker()
        {
            hackerMensagens.Clear();

            string[] linhas = new string[]
            {
                "Conectando ao servidor...",
                "Autenticando...",
                "Token de acesso: 8xf92-H4k3rX-1A2B",
                "Acesso concedido.",
                "Extraindo dados confidenciais...",
                "███▓▒░ 35% completo",
                "███▓▒░ 67% completo",
                "███▓▒░ 89% completo",
                "Upload para servidor externo...",
                "Processo finalizado com sucesso.",
                "🟢 Missão cumprida. 😎"
            };

            foreach (string linha in linhas)
                hackerMensagens.Enqueue(linha);

            hackerTimer.Start();
        }

        private void HackerTimer_Tick(object sender, EventArgs e)
        {
            if (hackerMensagens.Count > 0)
            {
                string linha = hackerMensagens.Dequeue();
                txtSaida.AppendText("\r\n" + linha);
            }
            else
            {
                hackerTimer.Stop();
            }
        }
    }
}

