namespace BuildLab
{
    partial class GestaoUtilizadores
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestaoUtilizadores));
            this.label1 = new System.Windows.Forms.Label();
            this.ListUtilizadores = new System.Windows.Forms.ListView();
            this.BotaoLimpar = new System.Windows.Forms.Button();
            this.NumeroRegistos = new System.Windows.Forms.Label();
            this.BotaoInserir = new System.Windows.Forms.Button();
            this.BotaoAtualizar = new System.Windows.Forms.Button();
            this.BotaoEliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Role = new System.Windows.Forms.ComboBox();
            this.IdUtilizador = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IsActive = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestorTutilizadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirSuporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarSessaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestor de Utilizadores ";
            // 
            // ListUtilizadores
            // 
            this.ListUtilizadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListUtilizadores.HideSelection = false;
            this.ListUtilizadores.Location = new System.Drawing.Point(37, 71);
            this.ListUtilizadores.Name = "ListUtilizadores";
            this.ListUtilizadores.Size = new System.Drawing.Size(638, 159);
            this.ListUtilizadores.TabIndex = 2;
            this.ListUtilizadores.UseCompatibleStateImageBehavior = false;
            this.ListUtilizadores.SelectedIndexChanged += new System.EventHandler(this.ListUtilizadores_SelectedIndexChanged);
            // 
            // BotaoLimpar
            // 
            this.BotaoLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoLimpar.Location = new System.Drawing.Point(545, 412);
            this.BotaoLimpar.Name = "BotaoLimpar";
            this.BotaoLimpar.Size = new System.Drawing.Size(121, 42);
            this.BotaoLimpar.TabIndex = 19;
            this.BotaoLimpar.Text = "&Limpar";
            this.BotaoLimpar.UseVisualStyleBackColor = true;
            this.BotaoLimpar.Click += new System.EventHandler(this.BotaoLimpar_Click);
            // 
            // NumeroRegistos
            // 
            this.NumeroRegistos.AutoSize = true;
            this.NumeroRegistos.Location = new System.Drawing.Point(36, 233);
            this.NumeroRegistos.Name = "NumeroRegistos";
            this.NumeroRegistos.Size = new System.Drawing.Size(35, 13);
            this.NumeroRegistos.TabIndex = 3;
            this.NumeroRegistos.Text = "label2";
            // 
            // BotaoInserir
            // 
            this.BotaoInserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoInserir.Location = new System.Drawing.Point(425, 412);
            this.BotaoInserir.Name = "BotaoInserir";
            this.BotaoInserir.Size = new System.Drawing.Size(106, 42);
            this.BotaoInserir.TabIndex = 18;
            this.BotaoInserir.Text = "&Inserir";
            this.BotaoInserir.UseVisualStyleBackColor = true;
            this.BotaoInserir.Click += new System.EventHandler(this.BotaoInserir_Click);
            // 
            // BotaoAtualizar
            // 
            this.BotaoAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoAtualizar.Location = new System.Drawing.Point(425, 460);
            this.BotaoAtualizar.Name = "BotaoAtualizar";
            this.BotaoAtualizar.Size = new System.Drawing.Size(106, 37);
            this.BotaoAtualizar.TabIndex = 20;
            this.BotaoAtualizar.Text = "&Atualizar";
            this.BotaoAtualizar.UseVisualStyleBackColor = true;
            this.BotaoAtualizar.Click += new System.EventHandler(this.BotaoAtualizar_Click);
            // 
            // BotaoEliminar
            // 
            this.BotaoEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoEliminar.Location = new System.Drawing.Point(545, 460);
            this.BotaoEliminar.Name = "BotaoEliminar";
            this.BotaoEliminar.Size = new System.Drawing.Size(121, 37);
            this.BotaoEliminar.TabIndex = 21;
            this.BotaoEliminar.Text = "&Eliminar";
            this.BotaoEliminar.UseVisualStyleBackColor = true;
            this.BotaoEliminar.Click += new System.EventHandler(this.BotaoEliminar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Usetname";
            // 
            // Nome
            // 
            this.Nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nome.Location = new System.Drawing.Point(37, 327);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(317, 20);
            this.Nome.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "&Password";
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(37, 379);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(315, 20);
            this.Password.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "&Role";
            // 
            // Role
            // 
            this.Role.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Role.FormattingEnabled = true;
            this.Role.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.Role.Location = new System.Drawing.Point(37, 424);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(315, 21);
            this.Role.TabIndex = 11;
            // 
            // IdUtilizador
            // 
            this.IdUtilizador.AutoSize = true;
            this.IdUtilizador.Location = new System.Drawing.Point(59, 289);
            this.IdUtilizador.Name = "IdUtilizador";
            this.IdUtilizador.Size = new System.Drawing.Size(35, 13);
            this.IdUtilizador.TabIndex = 5;
            this.IdUtilizador.Text = "label7";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "IsActive";
            // 
            // IsActive
            // 
            this.IsActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IsActive.FormattingEnabled = true;
            this.IsActive.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.IsActive.Location = new System.Drawing.Point(37, 476);
            this.IsActive.Name = "IsActive";
            this.IsActive.Size = new System.Drawing.Size(318, 21);
            this.IsActive.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestorTutilizadorToolStripMenuItem,
            this.gerirSuporteToolStripMenuItem,
            this.gerirBuildsToolStripMenuItem,
            this.terminarSessaoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestorTutilizadorToolStripMenuItem
            // 
            this.gestorTutilizadorToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gestorTutilizadorToolStripMenuItem.Name = "gestorTutilizadorToolStripMenuItem";
            this.gestorTutilizadorToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.gestorTutilizadorToolStripMenuItem.Text = "GestorUtilizadores";
            this.gestorTutilizadorToolStripMenuItem.Click += new System.EventHandler(this.gestorTutilizadorToolStripMenuItem_Click);
            // 
            // gerirSuporteToolStripMenuItem
            // 
            this.gerirSuporteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirSuporteToolStripMenuItem.Name = "gerirSuporteToolStripMenuItem";
            this.gerirSuporteToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.gerirSuporteToolStripMenuItem.Text = "GerirSuporte";
            this.gerirSuporteToolStripMenuItem.Click += new System.EventHandler(this.gerirSuporteToolStripMenuItem_Click);
            // 
            // gerirBuildsToolStripMenuItem
            // 
            this.gerirBuildsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirBuildsToolStripMenuItem.Name = "gerirBuildsToolStripMenuItem";
            this.gerirBuildsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.gerirBuildsToolStripMenuItem.Text = "GerirBuilds";
            this.gerirBuildsToolStripMenuItem.Click += new System.EventHandler(this.gerirBuildsToolStripMenuItem_Click);
            // 
            // terminarSessaoToolStripMenuItem
            // 
            this.terminarSessaoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminarSessaoToolStripMenuItem.Name = "terminarSessaoToolStripMenuItem";
            this.terminarSessaoToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.terminarSessaoToolStripMenuItem.Text = "Terminar Sessao";
            this.terminarSessaoToolStripMenuItem.Click += new System.EventHandler(this.terminarSessaoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "&Phone";
            // 
            // Phone
            // 
            this.Phone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Phone.Location = new System.Drawing.Point(425, 327);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(241, 20);
            this.Phone.TabIndex = 15;
            this.Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Phone_KeyPress);
            // 
            // Email
            // 
            this.Email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Email.Location = new System.Drawing.Point(425, 379);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(241, 20);
            this.Email.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "&Email";
            // 
            // GestaoUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 509);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsActive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.IdUtilizador);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BotaoEliminar);
            this.Controls.Add(this.BotaoAtualizar);
            this.Controls.Add(this.BotaoInserir);
            this.Controls.Add(this.NumeroRegistos);
            this.Controls.Add(this.BotaoLimpar);
            this.Controls.Add(this.ListUtilizadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GestaoUtilizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestaoUtilizadores_FormClosed);
            this.Load += new System.EventHandler(this.FormGestaoUtilizadores_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ListUtilizadores;
        private System.Windows.Forms.Button BotaoLimpar;
        private System.Windows.Forms.Label NumeroRegistos;
        private System.Windows.Forms.Button BotaoInserir;
        private System.Windows.Forms.Button BotaoAtualizar;
        private System.Windows.Forms.Button BotaoEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Role;
        private System.Windows.Forms.Label IdUtilizador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox IsActive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestorTutilizadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirSuporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirBuildsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem terminarSessaoToolStripMenuItem;
    }
}
