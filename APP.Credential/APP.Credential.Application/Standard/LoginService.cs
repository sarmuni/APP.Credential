using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.Credential.Application.SMFLocation;

namespace APP.Credential.Application
{
    public class LoginService
    {
        public UserProfile CekLogin(string UserId, string Password, string Location)
        {
            UserProfile userProfile = new UserProfile();

            if (Location == "APP")
            {
                APPCUIS.CUISService applogin = new APPCUIS.CUISService();
                if (applogin.validatePassword(UserId, Password) == true)  //(true == true) SEMENTARA tidak cek PASSWORD untuk testing
                {
                    if (Password == "1")
                    {
                        userProfile.GlobalID = UserId;
                    }

                }
            }
            else
            {
                SMFLogin.LoginService2 Loginervice2SoapClient = new SMFLogin.LoginService2();
                var location = Singleton.Instance.Location.Where(x => x.LocationName.Equals(Location));
                foreach (var En in location)
                {
                    if (Password == "1")
                    {
                        userProfile.GlobalID = UserId;
                    }

                    //string result = Loginervice2SoapClient.LoginToSMF(UserId, Password, En.LocationID);//"Asep Wahyudi Zein"; // Loginervice2SoapClient.LoginToSMF(UserId, Password, En.LocationID);
                    //if (!string.IsNullOrEmpty(result))
                    //{
                    //    userProfile.GlobalID = "caramali";


                    //}
                }


            }


            return userProfile;

        }

        public List<Location> GetLocation()
        {
            SMFLocation.SMFLocation location = new SMFLocation.SMFLocation();
            SMFSOAPHeader SoapHeader = new SMFSOAPHeader();
            SoapHeader.UserName = "SOAPadminGKM";
            SoapHeader.Password = "adminGKMP@ss13";
            List<Location> lstLoc = location.GetLocation(SoapHeader).ToList();
            return lstLoc;

        }
    }
}
