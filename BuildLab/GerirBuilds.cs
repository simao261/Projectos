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
    public partial class GerirBuilds : Form
    {
        private string connectionString = "server=localhost;database=buildlab_forms;uid=root;pwd=;";

        public GerirBuilds()
        {
            InitializeComponent();
            CarregarBuilds();
            ConfigurarListView();
        }

        private void gerirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestaoUtilizadores gestaoUtilizadores = new GestaoUtilizadores();
            gestaoUtilizadores.ShowDialog();


        }

        private void gerirBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirBuilds gerirBuilds = new GerirBuilds();
            gerirBuilds.ShowDialog();
            
        }

        private void gerirSuporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirSuporte gerirSuporte = new GerirSuporte();
            gerirSuporte.ShowDialog();
            
        }

        private void GerirBuilds_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void CarregarBuilds()
        {
            try
            {
                listViewgerirbuilds.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ID, UserID, BuildName, Components, TotalPrice, CreatedAt FROM Builds ORDER BY CreatedAt DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ID"].ToString());
                            item.SubItems.Add(reader["UserID"].ToString());
                            item.SubItems.Add(reader["BuildName"].ToString());
                            item.SubItems.Add(reader["Components"].ToString());
                            item.SubItems.Add(reader["TotalPrice"].ToString());
                            item.SubItems.Add(Convert.ToDateTime(reader["CreatedAt"]).ToString("yyyy-MM-dd"));

                            listViewgerirbuilds.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar builds: " + ex.Message);
            }
        }

        private void ConfigurarListView()
        {
            listViewgerirbuilds.View = View.Details;
            listViewgerirbuilds.FullRowSelect = true;
            listViewgerirbuilds.GridLines = false;  

            listViewgerirbuilds.Columns.Clear();
            listViewgerirbuilds.Columns.Add("ID", 50);
            listViewgerirbuilds.Columns.Add("UserID", 70);
            listViewgerirbuilds.Columns.Add("BuildName", 120);
            listViewgerirbuilds.Columns.Add("Components", -2); // -2 = auto-ajusta ao conteúdo
            listViewgerirbuilds.Columns.Add("Preço (€)", 80);
            listViewgerirbuilds.Columns.Add("Data", 90);
        }

        private void GerirBuilds_Load(object sender, EventArgs e)
        {
            
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

        private void GerirBuilds_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
