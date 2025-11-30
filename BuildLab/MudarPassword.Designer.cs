namespace BuildLab
{
    partial class MudarPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MudarPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxPasswordAntiga = new System.Windows.Forms.TextBox();
            this.TextBoxPasswordNova = new System.Windows.Forms.TextBox();
            this.TextBoxConfirmar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BotaoConfirmar = new System.Windows.Forms.Button();
            this.BotaoCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password atual:";
            // 
            // TextBoxPasswordAntiga
            // 
            this.TextBoxPasswordAntiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPasswordAntiga.Location = new System.Drawing.Point(200, 61);
            this.TextBoxPasswordAntiga.Name = "TextBoxPasswordAntiga";
            this.TextBoxPasswordAntiga.PasswordChar = '*';
            this.TextBoxPasswordAntiga.Size = new System.Drawing.Size(181, 20);
            this.TextBoxPasswordAntiga.TabIndex = 1;
            // 
            // TextBoxPasswordNova
            // 
            this.TextBoxPasswordNova.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPasswordNova.Location = new System.Drawing.Point(200, 100);
            this.TextBoxPasswordNova.Name = "TextBoxPasswordNova";
            this.TextBoxPasswordNova.PasswordChar = '*';
            this.TextBoxPasswordNova.Size = new System.Drawing.Size(181, 20);
            this.TextBoxPasswordNova.TabIndex = 3;
            // 
            // TextBoxConfirmar
            // 
            this.TextBoxConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxConfirmar.Location = new System.Drawing.Point(200, 144);
            this.TextBoxConfirmar.Name = "TextBoxConfirmar";
            this.TextBoxConfirmar.PasswordChar = '*';
            this.TextBoxConfirmar.Size = new System.Drawing.Size(181, 20);
            this.TextBoxConfirmar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nova Password:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirme a Password:";
            // 
            // BotaoConfirmar
            // 
            this.BotaoConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoConfirmar.Location = new System.Drawing.Point(158, 203);
            this.BotaoConfirmar.Name = "BotaoConfirmar";
            this.BotaoConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BotaoConfirmar.TabIndex = 6;
            this.BotaoConfirmar.Text = "Confirmar";
            this.BotaoConfirmar.UseVisualStyleBackColor = true;
            this.BotaoConfirmar.Click += new System.EventHandler(this.BotaoConfirmar_Click);
            // 
            // BotaoCancelar
            // 
            this.BotaoCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoCancelar.Location = new System.Drawing.Point(239, 204);
            this.BotaoCancelar.Name = "BotaoCancelar";
            this.BotaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.BotaoCancelar.TabIndex = 7;
            this.BotaoCancelar.Text = "Cancelar";
            this.BotaoCancelar.UseVisualStyleBackColor = true;
            this.BotaoCancelar.Click += new System.EventHandler(this.BotaoCancelar_Click);
            // 
            // MudarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 239);
            this.Controls.Add(this.BotaoCancelar);
            this.Controls.Add(this.BotaoConfirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxConfirmar);
            this.Controls.Add(this.TextBoxPasswordNova);
            this.Controls.Add(this.TextBoxPasswordAntiga);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MudarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MudarPassword";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MudarPassword_FormClosed);
            this.Load += new System.EventHandler(this.MudarPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxPasswordAntiga;
        private System.Windows.Forms.TextBox TextBoxPasswordNova;
        private System.Windows.Forms.TextBox TextBoxConfirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BotaoConfirmar;
        private System.Windows.Forms.Button BotaoCancelar;
    }
}