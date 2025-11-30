using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BuildLab
{
    public partial class CriarConta : Form
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        private void CriarConta_Load(object sender, EventArgs e)
        {

        }

        private void BotaoOk_Click(object sender, EventArgs e)
        {
            // 1. Validação de campos vazios
            if (string.IsNullOrWhiteSpace(txtnome.Text) ||
                string.IsNullOrWhiteSpace(txtpass.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validação de email
            if (!Regex.IsMatch(txtemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("O email não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validar número de telemóvel
            if (txtphone.Text.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(LigacaoDB.GetConnectionString()))
                {
                    // Verificar se já existe Username, Email ou Phone
                    var existente = connection.QueryFirstOrDefault<User>(
                        "SELECT * FROM Users WHERE Username = @Username OR Email = @Email OR Phone = @Phone",
                        new { Username = txtnome.Text, Email = txtemail.Text, Phone = txtphone.Text });

                    if (existente != null)
                    {
                        MessageBox.Show("Já existe uma conta com este Username, Email ou Telemóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Inserir novo utilizador
                    var sql = @"INSERT INTO Users (Username, Password, Email, Phone, Role, IsActive) 
                                VALUES (@Username, @Password, @Email, @Phone, 'user', 1)";

                    int i = connection.Execute(sql, new
                    {
                        Username = txtnome.Text,
                        Password = txtpass.Text,
                        Email = txtemail.Text,
                        Phone = txtphone.Text
                    });

                    if (i == 1)
                    {
                        MessageBox.Show("Conta criada com sucesso! Agora podes iniciar sessão.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuildLab buildLab = new BuildLab();
                        buildLab.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar conta. Tenta novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro na BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BotaoVoltar_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var formLogin = new BuildLab(); 
            formLogin.ShowDialog();

            
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // cancela qualquer letra ou símbolo
            }

            // Impedir mais do que 9 dígitos
            if (char.IsDigit(e.KeyChar) && txtphone.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }
    }
}
    
    

