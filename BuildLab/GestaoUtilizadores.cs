using Dapper;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BuildLab
{
    public partial class GestaoUtilizadores : Form
    {
        private List<User> Utilizadores;
        public GestaoUtilizadores()
        {
            InitializeComponent();
        }

        private void FormGestaoUtilizadores_Load(object sender, EventArgs e)
        {
            // Inicializar a ListView
            ListUtilizadores.View = View.Details;
            ListUtilizadores.FullRowSelect = true;
            ListUtilizadores.Columns.Add("ID", 50, HorizontalAlignment.Left);
            ListUtilizadores.Columns.Add("Username", 100, HorizontalAlignment.Left);
            ListUtilizadores.Columns.Add("Role", 80, HorizontalAlignment.Left);
            ListUtilizadores.Columns.Add("Ativo", 60, HorizontalAlignment.Left);
            ListUtilizadores.Columns.Add("Phone", 100, HorizontalAlignment.Left);
            ListUtilizadores.Columns.Add("Email", 150, HorizontalAlignment.Left);


            // Obter o número de Utilizadores na base de dados
            using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
            {
                int n = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users");
                NumeroRegistos.Text = $"{n} utilizadores";

            }

            Inicializar();

            Phone.MaxLength = 9;

        }

        private void ListUtilizadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListUtilizadores.SelectedItems.Count > 0)
            {
                int id = int.Parse(ListUtilizadores.SelectedItems[0].SubItems[0].Text);
                BindUser(id);
            }

        }

        private void BindUser(int id)
        {
            User user = Utilizadores.Find(x => x.Id == id);
            if (user != null)
            {
                IdUtilizador.Text = user.Id.ToString();
                Nome.Text = user.Username;
                Password.Text = user.Password;
                Role.Text = user.Role;
                IsActive.Text = user.IsActive ? "Sim" : "Não";
                Phone.Text = user.Phone ?? "";
                Email.Text = user.Email ?? "";
            }
        }

        private void Inicializar()
        {
            ListUtilizadores.Items.Clear();
            IdUtilizador.Text = "";
            Nome.Text = "";
            Password.Text = "";
            Role.SelectedIndex = -1;
            IsActive.SelectedIndex = -1;
            Phone.Text = "";
            Email.Text = "";

            try
            {
                using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                {
                    int n = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users");
                    NumeroRegistos.Text = $"{n} utilizadores";

                    var sql = "SELECT * FROM Users";
                    Utilizadores = connection.Query<User>(sql).ToList();

                    foreach (User u in Utilizadores)
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                            u.Id.ToString(),
                            u.Username,
                            u.Role,
                            u.IsActive ? "Sim" : "Não",
                            u.Phone ?? "",
                            u.Email ?? ""
                        });

                        ListUtilizadores.Items.Add(item);
                    }
                }
            }
            catch (MySqlException ex)
            {
                string msg = "Ocorreu um erro ao tentar utilizar a base de dados";
                if (ex.Number == 1042)
                    msg += "\n\nDetalhes: erro de ligação ao servidor de BD";
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gerirSuporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirSuporte gerirSuporte = new GerirSuporte();
            gerirSuporte.ShowDialog();
            
        }

        private void gestorTutilizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestaoUtilizadores gestaoUtilizadores = new GestaoUtilizadores();
            gestaoUtilizadores.ShowDialog();
            

        }

        private void BotaoAtualizar_Click(object sender, EventArgs e)
        {
            if (ListUtilizadores.SelectedItems.Count > 0)
            {
                if (!Email.Text.Contains("@"))
                {
                    MessageBox.Show("Email inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var sql = "UPDATE Users SET Username=@username, Password=@password, Role=@role, IsActive=@isActive, Phone=@phone, Email=@email WHERE ID=@id";
                    using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                    {
                        int i = connection.Execute(sql, new
                        {
                            username = Nome.Text,
                            password = Password.Text,
                            role = Role.Text,
                            isActive = IsActive.Text == "Sim",
                            phone = Phone.Text,
                            email = Email.Text,
                            id = IdUtilizador.Text
                        });

                        if (i == 1)
                        {
                            Inicializar();
                            MessageBox.Show("Utilizador atualizado com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar utilizador.", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro na BD ao tentar atualizar utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void BotaoInserir_Click(object sender, EventArgs e)
        {
            if (IdUtilizador.Text == "")
            {
                if (!Email.Text.Contains("@"))
                {
                    MessageBox.Show("Email inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var sql = "INSERT INTO Users (Username, Password, Role, IsActive, Phone, Email) VALUES(@username, @password, @role, @isActive, @phone, @email)";
                    using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                    {
                        int i = connection.Execute(sql, new
                        {
                            username = Nome.Text,
                            password = Password.Text,
                            role = Role.Text,
                            isActive = IsActive.Text == "Sim",
                            phone = Phone.Text,
                            email = Email.Text
                        });

                        if (i == 1)
                        {
                            Inicializar();
                            MessageBox.Show("Utilizador inserido com sucesso!", "Inserir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao inserir utilizador.", "Inserir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro na BD ao tentar inserir utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Já existe um utilizador carregado. Limpa os dados para inserir novo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BotaoLimpar_Click(object sender, EventArgs e)
        {
            IdUtilizador.Text = "";
            Nome.Text = "";
            Password.Text = "";
            Role.SelectedIndex = -1;
            IsActive.SelectedIndex = -1;
            Phone.Text = "";
            Email.Text = "";

        }

        private void BotaoEliminar_Click(object sender, EventArgs e)
        {
            if (ListUtilizadores.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Confirma a eliminação do utilizador?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int id = int.Parse(ListUtilizadores.SelectedItems[0].SubItems[0].Text);

                    try
                    {
                        using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                        {
                            int i = connection.Execute("DELETE FROM Users WHERE ID = @ID", new { ID = id });

                            if (i == 1)
                            {
                                Inicializar();
                                MessageBox.Show("Utilizador eliminado!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Erro ao eliminar o utilizador.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("Erro na BD ao tentar eliminar o utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gerirBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirBuilds gerirBuilds = new GerirBuilds();
            gerirBuilds.ShowDialog();
            
        }

        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void terminarSessaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Limpa o utilizador atual
            Sessao.UtilizadorAtual = null;
            // Fecha a form atual
            this.Hide();
            // Mostra novamente a form de autenticação
            BuildLab login = new BuildLab();
            login.Show();
        }

        private void GestaoUtilizadores_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

