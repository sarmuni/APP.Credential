using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using APP.Credential.Application;
using APP.Framework;
using APP.Credential.Domain;


namespace APP.Credential.Desktop
{
    public partial class frmLogin : Form
    {
        public ApplAppService applAppService;
        public UserActivity userActivity;

        public frmLogin()
        {
            InitializeComponent();
        }

        private List<string> listDomain()
        {
            IDictionary<string, string> dcDomain = new Dictionary<string, string>();


            if (Singleton.Instance.Location == null)
            {
                LoginService loginService = new LoginService();
                Singleton.Instance.Location = loginService.GetLocation();
            }


            List<string> lstDomain = Singleton.Instance.Location.Select(d => d.LocationName).Distinct().ToList();



            return lstDomain;

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbLocation.DataSource = listDomain();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginService loginService = new LoginService();

            string userId = tbName.Text;
            string password = tbPassword.Text;
            string location = cmbLocation.Text;

            UserProfile userProfile = loginService.CekLogin(userId, password, location);


            if (userProfile != null && !string.IsNullOrEmpty(userProfile.GlobalID))
            {

                userProfile.GlobalID = userProfile.GlobalID;
                //   userProfile.WindowsLogin =userProfile
                userProfile.IPAddress = "172.30.98.9";//GetIPAddress();
                userProfile.WebBrowser = "chrome";// GetBrowser();
                userProfile.ApplicationMode = APP.Framework.Enumeration.ApplicationMode.Production;
                //userProfile.DebuggerID = "simulateUser";
                userProfile.DeviceID = "deviceID";
                Singleton.Instance.userProfile = userProfile;
                applAppService = new ApplAppService(Singleton.Instance.userProfile);
                MsUserAppService msUserAppService = new MsUserAppService(Singleton.Instance.userProfile);
                List<MsUser> msUserLst = msUserAppService.GetMsUserList().Where(x => x.UserID.Equals(Singleton.Instance.userProfile.GlobalID)).ToList();
                string userRole = "";
                foreach (var item in msUserLst)
                {

                    if (userRole != "")
                    {
                        userRole += "+";
                    }
                    userRole += item.UserRoleID;
                }
                //to be retrieved from DB
                if (userRole == "")
                {
                    //Error("you do not have permission to access this application");
                    //return RedirectToAction("Index");
                    lblNotify.Text = "Invalid Login";
                    errorProvider1.SetError(lblNotify, "Invalid Login");
                }
                else
                {


                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    userActivity.Action = "Login";
                    userActivity.FormName = "Login.aspx";
                    userActivity.Description = "Login Success";
                    applAppService.LogUserActivity(userActivity);
                }

                // Session["UserProfile"] = userProfile;
            }
            else
            {
                lblNotify.Text = "Invalid Login";
                errorProvider1.SetError(lblNotify, "Invalid Login");
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
