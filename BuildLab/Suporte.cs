using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace BuildLab
{
    public partial class Suporte : Form
    {
        public Suporte()
        {
            InitializeComponent();
        }

        private void Suporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Sessao.TerminandoSessao) // só volta se não for logout
            {
                new Utilizador().Show();
            }
        }

        private void BotaoEnviar_Click(object sender, EventArgs e)
        {
            // Valida se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(Assunto.Text) || string.IsNullOrWhiteSpace(Mensagem.Text))
            {
                MessageBox.Show("Preenche todos os campos antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                {
                    var sql = "INSERT INTO Support (UserID, Subject, Message, CreatedAt) VALUES (@userID, @subject, @message, @createdAt)";

                    int i = connection.Execute(sql, new
                    {
                        userID = Sessao.UtilizadorAtual.Id,
                        subject = Assunto.Text,
                        message = Mensagem.Text,
                        createdAt = DateTime.Now.ToString("yyyy-MM-dd")
                    });

                    if (i == 1)
                    {
                        MessageBox.Show("Mensagem enviada com sucesso!", "Suporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Assunto.Clear();
                        Mensagem.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao enviar mensagem de suporte.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro na BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoCancelarSuporte_Click(object sender, EventArgs e)
        {
            Assunto.Clear();
            Mensagem.Clear();
            this.Close();
        }

        private void BotaoVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Utilizador utilizador = new Utilizador();
            utilizador.ShowDialog();

        }
    }
}
