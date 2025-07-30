namespace terminal
{
    partial class FormTerminal
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
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSaida
            // 
            this.txtSaida.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSaida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSaida.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaida.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtSaida.Location = new System.Drawing.Point(0, 0);
            this.txtSaida.Multiline = true;
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.ReadOnly = true;
            this.txtSaida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSaida.Size = new System.Drawing.Size(800, 450);
            this.txtSaida.TabIndex = 0;
            this.txtSaida.Text = "aa";
            // 
            // txtEntrada
            // 
            this.txtEntrada.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtEntrada.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtEntrada.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntrada.ForeColor = System.Drawing.Color.Honeydew;
            this.txtEntrada.Location = new System.Drawing.Point(0, 427);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(800, 23);
            this.txtEntrada.TabIndex = 1;
            this.txtEntrada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntrada_KeyDown);
            // 
            // FormTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.txtSaida);
            this.Name = "FormTerminal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormTerminal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntrada_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSaida;
        private System.Windows.Forms.TextBox txtEntrada;
    }
}

