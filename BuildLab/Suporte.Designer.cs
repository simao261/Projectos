namespace BuildLab
{
    partial class Suporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Suporte));
            this.Mensagem = new System.Windows.Forms.TextBox();
            this.BotaoEnviar = new System.Windows.Forms.Button();
            this.BotaoCancelarSuporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Assunto = new System.Windows.Forms.TextBox();
            this.BotaoVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mensagem
            // 
            this.Mensagem.Location = new System.Drawing.Point(27, 195);
            this.Mensagem.Multiline = true;
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.Size = new System.Drawing.Size(747, 180);
            this.Mensagem.TabIndex = 5;
            // 
            // BotaoEnviar
            // 
            this.BotaoEnviar.Location = new System.Drawing.Point(303, 398);
            this.BotaoEnviar.Name = "BotaoEnviar";
            this.BotaoEnviar.Size = new System.Drawing.Size(75, 23);
            this.BotaoEnviar.TabIndex = 6;
            this.BotaoEnviar.Text = "Enviar";
            this.BotaoEnviar.UseVisualStyleBackColor = true;
            this.BotaoEnviar.Click += new System.EventHandler(this.BotaoEnviar_Click);
            // 
            // BotaoCancelarSuporte
            // 
            this.BotaoCancelarSuporte.Location = new System.Drawing.Point(384, 398);
            this.BotaoCancelarSuporte.Name = "BotaoCancelarSuporte";
            this.BotaoCancelarSuporte.Size = new System.Drawing.Size(75, 23);
            this.BotaoCancelarSuporte.TabIndex = 7;
            this.BotaoCancelarSuporte.Text = "Cancelar ";
            this.BotaoCancelarSuporte.UseVisualStyleBackColor = true;
            this.BotaoCancelarSuporte.Click += new System.EventHandler(this.BotaoCancelarSuporte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Suporte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mensagem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Assunto";
            // 
            // Assunto
            // 
            this.Assunto.Location = new System.Drawing.Point(27, 115);
            this.Assunto.Multiline = true;
            this.Assunto.Name = "Assunto";
            this.Assunto.Size = new System.Drawing.Size(747, 58);
            this.Assunto.TabIndex = 3;
            // 
            // BotaoVoltar
            // 
            this.BotaoVoltar.Location = new System.Drawing.Point(30, 22);
            this.BotaoVoltar.Name = "BotaoVoltar";
            this.BotaoVoltar.Size = new System.Drawing.Size(84, 29);
            this.BotaoVoltar.TabIndex = 0;
            this.BotaoVoltar.Text = "↩️";
            this.BotaoVoltar.UseVisualStyleBackColor = true;
            this.BotaoVoltar.Click += new System.EventHandler(this.BotaoVoltar_Click);
            // 
            // Suporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BotaoVoltar);
            this.Controls.Add(this.Assunto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BotaoCancelarSuporte);
            this.Controls.Add(this.BotaoEnviar);
            this.Controls.Add(this.Mensagem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Suporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Suporte_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Mensagem;
        private System.Windows.Forms.Button BotaoEnviar;
        private System.Windows.Forms.Button BotaoCancelarSuporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Assunto;
        private System.Windows.Forms.Button BotaoVoltar;
    }
}