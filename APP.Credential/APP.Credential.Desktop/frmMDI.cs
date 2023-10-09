using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using APP.Credential.Application;
using APP.Credential.Domain.Dto;

namespace APP.Credential.Desktop
{
    public partial class frmMDI : Form
    {
        private int childFormNumber = 0;

        public frmMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            MenuAppService menuAppService = new MenuAppService(Singleton.Instance.userProfile);
            List<Getmenu> getMenuLst = menuAppService.getMenu(Singleton.Instance.userProfile.GlobalID);
            masterToolStripMenuItem.Visible = false;
            reportToolStripMenuItem.Visible = false;

            foreach (ToolStripMenuItem item in masterToolStripMenuItem.DropDownItems)
            {

                var data = getMenuLst.FirstOrDefault(x => x.MenuID.ToString() == item.Tag.ToString());
                if (data != null)
                {
                    masterToolStripMenuItem.Visible = true;
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }



            }
            foreach (ToolStripMenuItem item in reportToolStripMenuItem.DropDownItems)
            {

                var data = getMenuLst.FirstOrDefault(x => x.MenuID.ToString() == item.Tag.ToString());
                if (data != null)
                {
                    reportToolStripMenuItem.Visible = true;
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }



            }
        }

        private void headerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void demo5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void masterLainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void sampleReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void sample2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxExt(sender);
        }

        private void MessageBoxExt(Object obj)
        {
            MessageBox.Show(obj.ToString() + " Di Klik");
        }
    }
}
