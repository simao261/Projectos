namespace BuildLab
{
    partial class Utilizador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utilizador));
            this.Labelnome = new System.Windows.Forms.Label();
            this.BotaoMudarPass = new System.Windows.Forms.Button();
            this.Terminarsessao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Adicionarbuild = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewminhasbuilds = new System.Windows.Forms.ListView();
            this.BotaoSuporte = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewbuilds = new System.Windows.Forms.ListView();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Labelnome
            // 
            this.Labelnome.AutoSize = true;
            this.Labelnome.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labelnome.Location = new System.Drawing.Point(178, 13);
            this.Labelnome.Name = "Labelnome";
            this.Labelnome.Size = new System.Drawing.Size(109, 39);
            this.Labelnome.TabIndex = 0;
            this.Labelnome.Text = "label1";
            // 
            // BotaoMudarPass
            // 
            this.BotaoMudarPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoMudarPass.Location = new System.Drawing.Point(79, 96);
            this.BotaoMudarPass.Name = "BotaoMudarPass";
            this.BotaoMudarPass.Size = new System.Drawing.Size(129, 31);
            this.BotaoMudarPass.TabIndex = 2;
            this.BotaoMudarPass.Text = "Mudar Palavra-Passe";
            this.BotaoMudarPass.UseVisualStyleBackColor = true;
            this.BotaoMudarPass.Click += new System.EventHandler(this.BotaoMudarPass_Click);
            // 
            // Terminarsessao
            // 
            this.Terminarsessao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Terminarsessao.Location = new System.Drawing.Point(394, 96);
            this.Terminarsessao.Name = "Terminarsessao";
            this.Terminarsessao.Size = new System.Drawing.Size(156, 31);
            this.Terminarsessao.TabIndex = 4;
            this.Terminarsessao.Text = "Terminar sessão";
            this.Terminarsessao.UseVisualStyleBackColor = true;
            this.Terminarsessao.Click += new System.EventHandler(this.Terminarsessao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bem-Vindo a aplicacao BuildLab!";
            // 
            // Adicionarbuild
            // 
            this.Adicionarbuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Adicionarbuild.Location = new System.Drawing.Point(258, 290);
            this.Adicionarbuild.Name = "Adicionarbuild";
            this.Adicionarbuild.Size = new System.Drawing.Size(117, 36);
            this.Adicionarbuild.TabIndex = 3;
            this.Adicionarbuild.Text = "Adicionar ao Perfil ";
            this.Adicionarbuild.UseVisualStyleBackColor = true;
            this.Adicionarbuild.Click += new System.EventHandler(this.Adicionarbuild_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(641, 374);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewminhasbuilds);
            this.tabPage1.Controls.Add(this.BotaoSuporte);
            this.tabPage1.Controls.Add(this.Labelnome);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BotaoMudarPass);
            this.tabPage1.Controls.Add(this.Terminarsessao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(633, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Perfil";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewminhasbuilds
            // 
            this.listViewminhasbuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewminhasbuilds.HideSelection = false;
            this.listViewminhasbuilds.Location = new System.Drawing.Point(17, 161);
            this.listViewminhasbuilds.Name = "listViewminhasbuilds";
            this.listViewminhasbuilds.Size = new System.Drawing.Size(608, 175);
            this.listViewminhasbuilds.TabIndex = 5;
            this.listViewminhasbuilds.UseCompatibleStateImageBehavior = false;
            // 
            // BotaoSuporte
            // 
            this.BotaoSuporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoSuporte.Location = new System.Drawing.Point(250, 109);
            this.BotaoSuporte.Name = "BotaoSuporte";
            this.BotaoSuporte.Size = new System.Drawing.Size(98, 31);
            this.BotaoSuporte.TabIndex = 3;
            this.BotaoSuporte.Text = "Suporte";
            this.BotaoSuporte.UseVisualStyleBackColor = true;
            this.BotaoSuporte.Click += new System.EventHandler(this.BotaoSuporte_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewbuilds);
            this.tabPage2.Controls.Add(this.textBoxname);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Adicionarbuild);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(633, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Build";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewbuilds
            // 
            this.listViewbuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewbuilds.HideSelection = false;
            this.listViewbuilds.Location = new System.Drawing.Point(6, 61);
            this.listViewbuilds.Name = "listViewbuilds";
            this.listViewbuilds.Size = new System.Drawing.Size(619, 213);
            this.listViewbuilds.TabIndex = 2;
            this.listViewbuilds.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxname
            // 
            this.textBoxname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxname.Location = new System.Drawing.Point(226, 19);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(180, 20);
            this.textBoxname.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "BuildName";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Utilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 373);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Utilizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Utilizador_FormClosed);
            this.Load += new System.EventHandler(this.Utilizador_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Labelnome;
        private System.Windows.Forms.Button BotaoMudarPass;
        private System.Windows.Forms.Button Terminarsessao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Adicionarbuild;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BotaoSuporte;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.ListView listViewminhasbuilds;
        private System.Windows.Forms.ListView listViewbuilds;
    }
}
