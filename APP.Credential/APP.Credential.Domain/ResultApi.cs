using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.Credential.Domain
{
    public class ResultApi
    {
    }

    public class ResultUserLogin
    {
        public Boolean success { get; set; }
        public Int32 code { get; set; }
        public String message { get; set; }
        public UserLoginData data { get; set; }
    }

    public class UserLoginData
    {
        public String name { get; set; }
        public String sap { get; set; }
        public String nik { get; set; }
        public String level { get; set; }
        public String costcenter { get; set; }
        public String role { get; set; }
    }

    public class ResultMobileVersion
    {
        public Boolean success { get; set; }
        public Int32 code { get; set; }
        public String message { get; set; }
        public VersionData data { get; set; }
    }

    public class VersionData
    {
        public String versionName { get; set; }
        public String versionCode { get; set; }
        public DateTime releaseDate { get; set; }
        public String downloadUrl { get; set; }
    }

    public class ResultDeviceID
    {
        public Boolean success { get; set; }
        public Int32 code { get; set; }
        public String message { get; set; }
        public DeviceData data { get; set; }
    }

    public class DeviceData
    {
        public String deviceID { get; set; }
    }

    public class ResultDomain
    {
        public bool success { get; set; }
        public Int32 code { get; set; }
        public string message { get; set; }
        public List<DomainData> data { get; set; }
    }

    public class DomainData
    {
        public string domainCode { get; set; }
        public string domainName { get; set; }
    }

}
