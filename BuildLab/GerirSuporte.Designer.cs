namespace BuildLab
{
    partial class GerirSuporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerirSuporte));
            this.listViewSuporte = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.BotaoResolvido = new System.Windows.Forms.Button();
            this.BotaoEliminar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gerirUtilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirSuporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarSessaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSuporte
            // 
            this.listViewSuporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSuporte.HideSelection = false;
            this.listViewSuporte.Location = new System.Drawing.Point(16, 33);
            this.listViewSuporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewSuporte.Name = "listViewSuporte";
            this.listViewSuporte.Size = new System.Drawing.Size(1033, 442);
            this.listViewSuporte.TabIndex = 1;
            this.listViewSuporte.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 4;
            // 
            // BotaoResolvido
            // 
            this.BotaoResolvido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoResolvido.Location = new System.Drawing.Point(385, 502);
            this.BotaoResolvido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BotaoResolvido.Name = "BotaoResolvido";
            this.BotaoResolvido.Size = new System.Drawing.Size(115, 37);
            this.BotaoResolvido.TabIndex = 2;
            this.BotaoResolvido.Text = "Resolvido";
            this.BotaoResolvido.UseVisualStyleBackColor = true;
            this.BotaoResolvido.Click += new System.EventHandler(this.BotaoResolvido_Click);
            // 
            // BotaoEliminar
            // 
            this.BotaoEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoEliminar.Location = new System.Drawing.Point(504, 502);
            this.BotaoEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BotaoEliminar.Name = "BotaoEliminar";
            this.BotaoEliminar.Size = new System.Drawing.Size(115, 37);
            this.BotaoEliminar.TabIndex = 3;
            this.BotaoEliminar.Text = "Eliminar";
            this.BotaoEliminar.UseVisualStyleBackColor = true;
            this.BotaoEliminar.Click += new System.EventHandler(this.BotaoEliminar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerirUtilizadoresToolStripMenuItem,
            this.gerirSuporteToolStripMenuItem,
            this.gerirBuildsToolStripMenuItem,
            this.terminarSessaoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gerirUtilizadoresToolStripMenuItem
            // 
            this.gerirUtilizadoresToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirUtilizadoresToolStripMenuItem.Name = "gerirUtilizadoresToolStripMenuItem";
            this.gerirUtilizadoresToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.gerirUtilizadoresToolStripMenuItem.Text = "GerirUtilizadores";
            this.gerirUtilizadoresToolStripMenuItem.Click += new System.EventHandler(this.gerirUtilizadoresToolStripMenuItem_Click);
            // 
            // gerirSuporteToolStripMenuItem
            // 
            this.gerirSuporteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirSuporteToolStripMenuItem.Name = "gerirSuporteToolStripMenuItem";
            this.gerirSuporteToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.gerirSuporteToolStripMenuItem.Text = "GerirSuporte";
            this.gerirSuporteToolStripMenuItem.Click += new System.EventHandler(this.gerirSuporteToolStripMenuItem_Click);
            // 
            // gerirBuildsToolStripMenuItem
            // 
            this.gerirBuildsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirBuildsToolStripMenuItem.Name = "gerirBuildsToolStripMenuItem";
            this.gerirBuildsToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.gerirBuildsToolStripMenuItem.Text = "GerirBuilds";
            this.gerirBuildsToolStripMenuItem.Click += new System.EventHandler(this.gerirBuildsToolStripMenuItem_Click);
            // 
            // terminarSessaoToolStripMenuItem
            // 
            this.terminarSessaoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminarSessaoToolStripMenuItem.Name = "terminarSessaoToolStripMenuItem";
            this.terminarSessaoToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.terminarSessaoToolStripMenuItem.Text = "Terminar Sessao ";
            this.terminarSessaoToolStripMenuItem.Click += new System.EventHandler(this.terminarSessaoToolStripMenuItem_Click);
            // 
            // GerirSuporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BotaoEliminar);
            this.Controls.Add(this.BotaoResolvido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewSuporte);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GerirSuporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GerirSuporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GerirSuporte_FormClosed);
            this.Load += new System.EventHandler(this.GerirSuporte_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSuporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotaoResolvido;
        private System.Windows.Forms.Button BotaoEliminar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gerirUtilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirSuporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirBuildsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarSessaoToolStripMenuItem;
    }
}