using Dapper;
using Dapper;
using MySql.Data.MySqlClient;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace BuildLab
{
    public partial class Utilizador : Form
    {

        private string connectionString = "Server=localhost;Database=buildlab_forms;Uid=root;Pwd=;";
       

        public Utilizador()
        {
            InitializeComponent();
            ConfigurarListViewBuilds();      // Configura a listView original
            ConfigurarListViewMinhasBuilds();// Configura a listView do utilizador
            CarregarBuildsPreDefinidas();
            CarregarMinhasBuilds();

            if (Sessao.UtilizadorAtual != null)
            {
                Labelnome.Text = "Olá, " + Sessao.UtilizadorAtual.Username + "!";
                Labelnome.Width = TextRenderer.MeasureText(Labelnome.Text, Labelnome.Font).Width + 10;
            }
            else
            {
                Labelnome.Text = "Olá, utilizador!";
            }

            

        }

        private void ConfigurarListViewBuilds()
        {
            listViewbuilds.View = View.Details;
            listViewbuilds.FullRowSelect = true;
            listViewbuilds.Columns.Clear();
            listViewbuilds.Columns.Add("Nome da Build", 200);
            listViewbuilds.Columns.Add("Componentes", 400);
            listViewbuilds.Columns.Add("Preço (€)", 100);
        }

        private void ConfigurarListViewMinhasBuilds()
        {
            listViewminhasbuilds.View = View.Details;
            listViewminhasbuilds.FullRowSelect = true;
            listViewminhasbuilds.Columns.Clear();
            listViewminhasbuilds.Columns.Add("Nome da Build", 200);
            listViewminhasbuilds.Columns.Add("Componentes", 400);
            listViewminhasbuilds.Columns.Add("Preço (€)", 100);
        }


        private void CarregarBuildsPreDefinidas()
        {
            try
            {
                listViewbuilds.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BuildName, Components, TotalPrice FROM Builds ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string buildName = reader["BuildName"] != DBNull.Value ? reader["BuildName"].ToString() : "";
                            string components = reader["Components"] != DBNull.Value ? reader["Components"].ToString() : "";
                            decimal price = reader["TotalPrice"] != DBNull.Value ? Convert.ToDecimal(reader["TotalPrice"]) : 0;

                            ListViewItem item = new ListViewItem(buildName);
                            item.SubItems.Add(components);
                            item.SubItems.Add(price.ToString("C2"));

                            listViewbuilds.Items.Add(item);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar builds: " + ex.Message);
            }
        }

        private void CarregarMinhasBuilds()
        {
            if (Sessao.UtilizadorAtual == null)
                return;

            try
            {
                listViewminhasbuilds.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BuildName, Components, TotalPrice FROM Builds WHERE UserID = @UserID ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", Sessao.UtilizadorAtual.Id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string buildName = reader["BuildName"] != DBNull.Value ? reader["BuildName"].ToString() : "";
                                string components = reader["Components"] != DBNull.Value ? reader["Components"].ToString() : "";
                                decimal price = reader["TotalPrice"] != DBNull.Value ? Convert.ToDecimal(reader["TotalPrice"]) : 0;

                                ListViewItem item = new ListViewItem(buildName);
                                item.SubItems.Add(components);
                                item.SubItems.Add(price.ToString("C2"));

                                listViewminhasbuilds.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as tuas builds: " + ex.Message);
            }
        }


        private void FormBuildscs_Load(object sender, EventArgs e)
        {
            

            CarregarBuildsPreDefinidas();  // mantém a ListView original intacta
            CarregarMinhasBuilds();
        }

        private void BotaoSuporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            Suporte suporte = new Suporte();
            suporte.ShowDialog();
            this.Close();
        }

        private void Utilizador_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Sessao.TerminandoSessao)
            {
                Application.Exit(); 
            }
        }
       

        private void Terminarsessao_Click(object sender, EventArgs e)
        {

            Sessao.TerminandoSessao = true;

            // limpa a sessão
            Sessao.UtilizadorAtual = null;

            // abre o login outra vez
            new BuildLab().Show();

            this.Close(); // fecha a form atual
        }

        private void BotaoMudarPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            MudarPassword mudarPassword = new MudarPassword(Sessao.UtilizadorAtual.Id);
            mudarPassword.ShowDialog();
        }

        private void Adicionarbuild_Click(object sender, EventArgs e)
        {
            if (listViewbuilds.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleciona uma build da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxname.Text))
            {
                MessageBox.Show("Insere um nome para a tua build.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var buildSelecionada = listViewbuilds.SelectedItems[0];
            string components = buildSelecionada.SubItems[1].Text;
            var utilizador = Sessao.UtilizadorAtual;

            if (utilizador == null)
            {
                MessageBox.Show("Erro: utilizador não autenticado.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO Builds (UserID, BuildName, Components, TotalPrice, CreatedAt) " +
                                         "VALUES (@UserID, @BuildName, @Components, @TotalPrice, CURDATE())";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", utilizador.Id);
                        cmd.Parameters.AddWithValue("@BuildName", textBoxname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Components", components);
                        cmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(buildSelecionada.SubItems[2].Text.Replace("€", "").Trim()));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Build adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxname.Clear();
                listViewbuilds.SelectedItems.Clear();
                CarregarBuildsPreDefinidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar build: " + ex.Message);
            }

            CarregarMinhasBuilds(); // Atualiza automaticamente a ListView do utilizador

        }

        private void Utilizador_Load(object sender, EventArgs e)
        {

        }
    }
}
