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
    public partial class MudarPassword : Form
    {
        private int userId;


        public MudarPassword(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void MudarPassword_Load(object sender, EventArgs e)
        {

        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxPasswordAntiga.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPasswordNova.Text) ||
                 string.IsNullOrWhiteSpace(TextBoxConfirmar.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TextBoxPasswordNova.Text != TextBoxConfirmar.Text)
            {
                MessageBox.Show("As passwords não coincidem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
            {
                // 1º verificar se a password antiga está correta
                var existe = connection.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM Users WHERE ID = @id AND Password = @passAntiga",
                    new { id = userId, passAntiga = TextBoxPasswordAntiga.Text });

                if (existe == 1)
                {
                    // Atualizar password
                    var linhas = connection.Execute(
                        "UPDATE Users SET Password = @nova WHERE ID = @id",
                        new { nova = TextBoxPasswordNova.Text, id = userId });

                    if (linhas == 1)
                    {
                        MessageBox.Show("Password alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar a password!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Password antiga incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MudarPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Utilizador formutilizador = new Utilizador();
            formutilizador.ShowDialog();
        }
    }
}
