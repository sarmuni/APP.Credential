using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using APP.Credential.Application;

namespace APP.Credential.Desktop
{

    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            frmLogin loginForm = new frmLogin();

            if (loginForm.ShowDialog() != DialogResult.Cancel)
            {
                frmMDI mainMdiForm = new frmMDI();

                loginForm.Dispose();
                loginForm = null;
                System.Windows.Forms.Application.Run(mainMdiForm);
            }



        }
    }
}
