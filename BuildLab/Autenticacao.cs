using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace BuildLab
{
    public partial class BuildLab : Form
    {
        public bool Autenticado { get; private set; } = false;
        public string Role { get; private set; } = "";


        private List<User> Users;

        public BuildLab()
        {
            InitializeComponent();
     
        }

        private void BotaoOk_Click(object sender, EventArgs e)
        {
            LabelFeedback.Visible = false;
            LabelFeedback.ForeColor = Color.Red;

            if (!String.IsNullOrWhiteSpace(Utilizador.Text) && !String.IsNullOrWhiteSpace(Password.Text))
            {
                try
                {
                    using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                    {
                        var user = connection.QueryFirstOrDefault<User>(
                            "SELECT * FROM Users WHERE IsActive = 1 AND Username = @Username AND Password = @Password",
                            new { Username = Utilizador.Text, Password = Password.Text });

                        if (user != null)
                        {
                            Sessao.UtilizadorAtual = user;
                            Autenticado = true;
                           

                            Role = user.Role;

                            if (user.Role == "admin")
                            {
                                MessageBox.Show("Login como ADMIN.");
                                new GestaoUtilizadores().Show();
                            }
                            else
                            {
                                MessageBox.Show("Login como UTILIZADOR.");
                                new Utilizador().Show();

                            }

                            this.Hide();
                        }
                        else
                        {
                            // Credenciais erradas
                            LabelFeedback.Text = "Utilizador ou palavra-passe inválidos!";
                            LabelFeedback.Visible = true;
                        }
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Ocorreu um erro de base de dados ao tentar efetuar a autenticação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LabelFeedback.Text = "Insira os dados de autenticação";
                LabelFeedback.Visible = true;
            }
        }

        private void BuildLab_Load(object sender, EventArgs e)
        {
            LabelFeedback.Visible = false; 

        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BuildLab_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Autenticado)
            {
                Application.Exit();
            }

        }

        private void BotaoCriarConta_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarConta criarConta = new CriarConta();
            criarConta.ShowDialog();
            
        }

        
    }
}
