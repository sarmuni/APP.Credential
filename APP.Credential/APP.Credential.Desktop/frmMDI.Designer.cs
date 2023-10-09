namespace APP.Credential.Desktop
{
    partial class frmMDI
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demo5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterLainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sample2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.demo5ToolStripMenuItem,
            this.masterLainToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // headerToolStripMenuItem
            // 
            this.headerToolStripMenuItem.Name = "headerToolStripMenuItem";
            this.headerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.headerToolStripMenuItem.Tag = "2";
            this.headerToolStripMenuItem.Text = "Header";
            this.headerToolStripMenuItem.Visible = false;
            this.headerToolStripMenuItem.Click += new System.EventHandler(this.headerToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.employeeToolStripMenuItem.Tag = "3";
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Visible = false;
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // demo5ToolStripMenuItem
            // 
            this.demo5ToolStripMenuItem.Name = "demo5ToolStripMenuItem";
            this.demo5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.demo5ToolStripMenuItem.Tag = "7";
            this.demo5ToolStripMenuItem.Text = "Demo 5";
            this.demo5ToolStripMenuItem.Visible = false;
            this.demo5ToolStripMenuItem.Click += new System.EventHandler(this.demo5ToolStripMenuItem_Click);
            // 
            // masterLainToolStripMenuItem
            // 
            this.masterLainToolStripMenuItem.Name = "masterLainToolStripMenuItem";
            this.masterLainToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masterLainToolStripMenuItem.Tag = "10";
            this.masterLainToolStripMenuItem.Text = "Master Lain";
            this.masterLainToolStripMenuItem.Visible = false;
            this.masterLainToolStripMenuItem.Click += new System.EventHandler(this.masterLainToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleReportToolStripMenuItem1,
            this.sample2ToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // sampleReportToolStripMenuItem1
            // 
            this.sampleReportToolStripMenuItem1.Name = "sampleReportToolStripMenuItem1";
            this.sampleReportToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.sampleReportToolStripMenuItem1.Tag = "9";
            this.sampleReportToolStripMenuItem1.Text = "Sample Report";
            this.sampleReportToolStripMenuItem1.Visible = false;
            this.sampleReportToolStripMenuItem1.Click += new System.EventHandler(this.sampleReportToolStripMenuItem1_Click);
            // 
            // sample2ToolStripMenuItem
            // 
            this.sample2ToolStripMenuItem.Name = "sample2ToolStripMenuItem";
            this.sample2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sample2ToolStripMenuItem.Tag = "12";
            this.sample2ToolStripMenuItem.Text = "Sample 2";
            this.sample2ToolStripMenuItem.Visible = false;
            this.sample2ToolStripMenuItem.Click += new System.EventHandler(this.sample2ToolStripMenuItem_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMDI";
            this.Text = "frmMDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demo5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterLainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sample2ToolStripMenuItem;
    }
}



