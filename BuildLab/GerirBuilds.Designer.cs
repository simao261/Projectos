namespace BuildLab
{
    partial class GerirBuilds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerirBuilds));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gerirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirSuporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarSessaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewgerirbuilds = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerirToolStripMenuItem,
            this.gerirSuporteToolStripMenuItem,
            this.gerirBuildsToolStripMenuItem,
            this.terminarSessaoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gerirToolStripMenuItem
            // 
            this.gerirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerirToolStripMenuItem.Name = "gerirToolStripMenuItem";
            this.gerirToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.gerirToolStripMenuItem.Text = "GerirUtilizadores";
            this.gerirToolStripMenuItem.Click += new System.EventHandler(this.gerirToolStripMenuItem_Click);
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
            this.terminarSessaoToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.terminarSessaoToolStripMenuItem.Text = "Terminar sessao";
            this.terminarSessaoToolStripMenuItem.Click += new System.EventHandler(this.terminarSessaoToolStripMenuItem_Click);
            // 
            // listViewgerirbuilds
            // 
            this.listViewgerirbuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewgerirbuilds.HideSelection = false;
            this.listViewgerirbuilds.Location = new System.Drawing.Point(13, 38);
            this.listViewgerirbuilds.Name = "listViewgerirbuilds";
            this.listViewgerirbuilds.Size = new System.Drawing.Size(775, 400);
            this.listViewgerirbuilds.TabIndex = 1;
            this.listViewgerirbuilds.UseCompatibleStateImageBehavior = false;
            // 
            // GerirBuilds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewgerirbuilds);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GerirBuilds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GerirBuilds";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GerirBuilds_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gerirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirSuporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirBuildsToolStripMenuItem;
        private System.Windows.Forms.ListView listViewgerirbuilds;
        private System.Windows.Forms.ToolStripMenuItem terminarSessaoToolStripMenuItem;
    }
}