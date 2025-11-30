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
    public partial class GerirSuporte : Form
    {
        private string connectionString = "server=localhost;database=buildlab_forms;uid=root;pwd=;";

        public GerirSuporte()
        {
            InitializeComponent();
            CarregarMensagens();
        }

        private void GerirSuporte_Load(object sender, EventArgs e)
        {
            listViewSuporte.View = View.Details;
            listViewSuporte.FullRowSelect = true;
            listViewSuporte.Columns.Add("ID", 50);
            listViewSuporte.Columns.Add("Assunto", 150);
            listViewSuporte.Columns.Add("Mensagem", 300);
            listViewSuporte.Columns.Add("Data", 100);
            listViewSuporte.Columns.Add("Status", 100);

        }

        private void CarregarMensagens()
         {
            listViewSuporte.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Subject, Message, CreatedAt, Status FROM Support ORDER BY CreatedAt DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Id"].ToString());
                        item.SubItems.Add(reader["Subject"].ToString());
                        item.SubItems.Add(reader["Message"].ToString());
                        item.SubItems.Add(reader["CreatedAt"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());

                        listViewSuporte.Items.Add(item);
                    }
                }
            }

        }
         private void BotaoResolvido_Click(object sender, EventArgs e)
         {
             if (listViewSuporte.SelectedItems.Count == 0)
             {
                 MessageBox.Show("Seleciona uma mensagem primeiro!");
                 return;
             }

             int id = int.Parse(listViewSuporte.SelectedItems[0].Text);

             using (MySqlConnection conn = new MySqlConnection(connectionString))
             {
                 conn.Open();
                string query = "DELETE FROM Support WHERE Id = @id";
                 using (MySqlCommand cmd = new MySqlCommand(query, conn))
                 {
                     cmd.Parameters.AddWithValue("@id", id);
                     cmd.ExecuteNonQuery();
                 }
             }

             MessageBox.Show("Mensagem marcada como resolvida!");
             CarregarMensagens();
         }

         private void BotaoEliminar_Click(object sender, EventArgs e)
         {
             if (listViewSuporte.SelectedItems.Count == 0)
             {
                 MessageBox.Show("Seleciona uma mensagem primeiro!");
                 return;
             }

             int id = int.Parse(listViewSuporte.SelectedItems[0].Text);

             DialogResult result = MessageBox.Show("Tens a certeza que queres eliminar esta mensagem?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (result == DialogResult.Yes)
             {
                 using (MySqlConnection conn = new MySqlConnection(connectionString))
                 {
                    conn.Open();
                    string query = "DELETE FROM Support WHERE Id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                     {
                         cmd.Parameters.AddWithValue("@id", id);
                         cmd.ExecuteNonQuery();
                     }
                 }

                 MessageBox.Show("Mensagem eliminada com sucesso!");
                 CarregarMensagens();
             }
         }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestaoUtilizadores gestaoUtilizadores = new GestaoUtilizadores();
            gestaoUtilizadores.ShowDialog();
           
        }

        private void gerirSuporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirSuporte gerirSuporte = new GerirSuporte();
            gerirSuporte.ShowDialog();
            
        }

        private void gerirBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerirBuilds gerirBuilds = new GerirBuilds();
            gerirBuilds.ShowDialog();
            
        }

        private void terminarSessaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sessao.UtilizadorAtual = null; // Limpa o utilizador atual

            this.Hide(); // esconde a form atual
            BuildLab login = new BuildLab();
            login.ShowDialog(); // abre o login modal
            
        }

        private void GerirSuporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Application.Exit();
        }
    }
}
