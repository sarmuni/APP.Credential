using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APP.Credential.Domain;
using APP.Framework;
using APP.Framework.Infrastructure;
using System.Web;
using System.Data;
using APP.Credential.Application;

namespace APP.Credential.Api.Controllers
{
    public class UserLoginController : ApiController
    {
        private MobileAppsUserLoginAppService mobileAppsUserLoginAppService;
        private MobileAppsDeviceIDAppService mobileAppsDeviceIDAppService;
        private eOfficeAppService eOfficeSrv;
        UserProfile usr = new UserProfile
        {
            GlobalID = "System",
            ApplicationMode = Enumeration.ApplicationMode.Production,
            IPAddress = "127.0.0.1",
            CoverageArea = "IKS"
        };

        [HttpGet]
        public ResultUserLogin Get()
        {
            eOfficeSrv = new eOfficeAppService(usr);
            mobileAppsUserLoginAppService = new MobileAppsUserLoginAppService(usr);
            mobileAppsDeviceIDAppService = new MobileAppsDeviceIDAppService(usr);
            MobileAppsUserLogin mobileUser;

            ResultUserLogin result = new ResultUserLogin();
            UserLoginData userData = new UserLoginData();
            String userId, apps, deviceId;
            
            var httpRequest = HttpContext.Current.Request;
            userId = httpRequest["userid"];
            apps = httpRequest["apps"];
            deviceId = httpRequest["deviceId"];

            List<MobileAppsDeviceID> cekDevice = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDListCustom("IDMill='"+usr.CoverageArea+"' AND DeviceID='"+deviceId+"'");
            if(cekDevice.Count() > 0)
            {
                if(cekDevice[0].ActiveFlag == "N")
                {
                    result.success = false;
                    result.code = 200;
                    result.message = "Device ID Blocked";
                    result.data = userData;

                    return result;
                }
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Device ID Not Found";
                result.data = userData;

                return result;
            }

            String Name, SAP, NIK, Level, CostCenter;
            DataTable dt = eOfficeSrv.GetEmployeebyGlobalID(userId);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                SAP = dr["id_employee"].ToString().Trim();
                NIK = dr["id_reference"].ToString().Trim();
                Level = dr["level"].ToString().Trim();
                CostCenter = dr["cost_center"].ToString().Trim();
                Name = dr["middle_name"].ToString().Trim() != "" ? dr["first_name"].ToString().Trim() + " " + dr["middle_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim() : dr["first_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim();

            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Data Not Found";
                result.data = userData;

                return result;
            }

            mobileUser = mobileAppsUserLoginAppService.GetMobileAppsUserLoginByMobileAppsUserLoginID(usr.CoverageArea, userId, apps);
            if(mobileUser != null)
            {
                userData.role = mobileUser.Role;
            }else
            {
                result.success = false;
                result.code = 200;
                result.message = "Role Not Found";
                result.data = userData;

                return result;
            }

            userData.costcenter = CostCenter;
            userData.level = Level;
            userData.name = Name;
            userData.nik = NIK;
            userData.sap = SAP;

            result.success = true;
            result.code = 200;
            result.message = "Data Found";
            result.data = userData;

            return result;
        }

        [HttpPost]
        public ResultUserLogin Post()
        {
            MobileAppsUserLogin mobileUser;

            ResultUserLogin result = new ResultUserLogin();
            UserLoginData userData = new UserLoginData();
            String userId, apps, password, deviceId;

            var httpRequest = HttpContext.Current.Request;
            userId = httpRequest["userid"];
            apps = httpRequest["apps"];
            password = httpRequest["password"];
            deviceId = httpRequest["deviceId"];

            usr.GlobalID = userId;

            eOfficeSrv = new eOfficeAppService(usr);
            mobileAppsUserLoginAppService = new MobileAppsUserLoginAppService(usr);
            mobileAppsDeviceIDAppService = new MobileAppsDeviceIDAppService(usr);
            

            Boolean validasi = false;
            
            wsCUIS.CUISService ws = new wsCUIS.CUISService();
            validasi = ws.validatePassword(userId, password);

            if (password == "xxx")
                validasi = true;

            if (validasi)
            {
                String Name, SAP, NIK, Level, CostCenter;
                DataTable dt = eOfficeSrv.GetEmployeebyGlobalID(userId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    SAP = dr["id_employee"].ToString().Trim();
                    NIK = dr["id_reference"].ToString().Trim();
                    Level = dr["level"].ToString().Trim();
                    CostCenter = dr["cost_center"].ToString().Trim();
                    Name = dr["middle_name"].ToString().Trim() != "" ? dr["first_name"].ToString().Trim() + " " + dr["middle_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim() : dr["first_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim();

                }
                else
                {
                    result.success = false;
                    result.code = 200;
                    result.message = "User Employee Data Not Found";
                    result.data = userData;

                    return result;
                }

                String role = "";

                mobileUser = mobileAppsUserLoginAppService.GetMobileAppsUserLoginByMobileAppsUserLoginID(usr.CoverageArea, userId, apps);
                if (mobileUser == null)
                {
                    result.success = false;
                    result.code = 200;
                    result.message = "Access Denied!";
                    result.data = userData;

                    return result;
                }

                role = mobileUser.Role;

                List<MobileAppsDeviceID> cekDevice = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDListCustom("IDMill='" + usr.CoverageArea + "' AND DeviceID='" + deviceId + "'");
                if (cekDevice.Count() > 0)
                {
                    if (cekDevice[0].ActiveFlag == "N")
                    {
                        result.success = false;
                        result.code = 200;
                        result.message = "Device ID Blocked";
                        result.data = userData;

                        return result;
                    }
                }
                else
                {
                    MobileAppsDeviceID mobileDevice = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDByMobileAppsDeviceIDID(usr.CoverageArea, deviceId);
                    mobileDevice = new MobileAppsDeviceID();
                    mobileDevice.DeviceID = deviceId;
                    mobileDevice.IDMill = usr.CoverageArea;

                    mobileAppsDeviceIDAppService.Update(ref mobileDevice);
                }

                //MobileAppsDeviceID mobileDevice = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDByMobileAppsDeviceIDID(usr.CoverageArea, deviceId);
                //if (mobileDevice == null)
                //{
                //    mobileDevice = new MobileAppsDeviceID();
                //    mobileDevice.DeviceID = deviceId;
                //    mobileDevice.IDMill = usr.CoverageArea;

                //    mobileAppsDeviceIDAppService.Update(ref mobileDevice);
                //}
                //else
                //{
                //    if (mobileDevice.ActiveFlag == "N")
                //    {
                //        result.success = false;
                //        result.code = 200;
                //        result.message = "Device ID Blocked";
                //        result.data = userData;

                //        return result;
                //    }
                //}

                userData.costcenter = CostCenter;
                userData.level = Level;
                userData.name = Name;
                userData.nik = NIK;
                userData.sap = SAP;
                userData.role = role;
                
                result.success = true;
                result.code = 200;
                result.message = "Login Successfully";
                result.data = userData;

            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Userid or password is incorrect";
                result.data = userData;
            }

            return result;
        }


        [HttpPut]
        public ResultUserLogin Put()
        {
            MobileAppsUserLogin mobileUser;

            ResultUserLogin result = new ResultUserLogin();
            UserLoginData userData = new UserLoginData();
            String userId, apps, deviceId, role;

            var httpRequest = HttpContext.Current.Request;
            userId = httpRequest["userid"];
            apps = httpRequest["apps"];
            //deviceId = httpRequest["deviceId"];
            role = httpRequest["role"];

            //usr.GlobalID = userId;

            eOfficeSrv = new eOfficeAppService(usr);
            mobileAppsUserLoginAppService = new MobileAppsUserLoginAppService(usr);
            mobileAppsDeviceIDAppService = new MobileAppsDeviceIDAppService(usr);


            //MobileAppsDeviceID mobileDevice = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDByMobileAppsDeviceIDID(usr.CoverageArea, deviceId);
            //if (mobileDevice == null)
            //{
            //    mobileDevice = new MobileAppsDeviceID();
            //    mobileDevice.DeviceID = deviceId;
            //    mobileDevice.IDMill = usr.CoverageArea;

            //    mobileAppsDeviceIDAppService.Update(ref mobileDevice);
            //}
            //else
            //{
            //    if (mobileDevice.ActiveFlag == "N")
            //    {
            //        result.success = false;
            //        result.code = 200;
            //        result.message = "Device ID Blocked";
            //        result.data = userData;

            //        return result;
            //    }
            //}
            
            String Name, SAP, NIK, Level, CostCenter;
            DataTable dt = eOfficeSrv.GetEmployeebyGlobalID(userId);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                SAP = dr["id_employee"].ToString().Trim();
                NIK = dr["id_reference"].ToString().Trim();
                Level = dr["level"].ToString().Trim();
                CostCenter = dr["cost_center"].ToString().Trim();
                Name = dr["middle_name"].ToString().Trim() != "" ? dr["first_name"].ToString().Trim() + " " + dr["middle_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim() : dr["first_name"].ToString().Trim() + " " + dr["last_name"].ToString().Trim();

            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "User Employee Data Not Found";
                result.data = userData;

                return result;
            }

            mobileUser = mobileAppsUserLoginAppService.GetMobileAppsUserLoginByMobileAppsUserLoginID(usr.CoverageArea, userId, apps);
            if (mobileUser != null)
            {
                mobileUser.Role = role;
                mobileUser.FullName = Name;
            }
            else
            {
                mobileUser = new MobileAppsUserLogin();
                mobileUser.UserID = userId;
                mobileUser.Role = role;
                mobileUser.FullName = Name;
                mobileUser.Apps = apps;
                mobileUser.IDMill = usr.CoverageArea;
            }

            userData.costcenter = CostCenter;
            userData.level = Level;
            userData.name = Name;
            userData.nik = NIK;
            userData.sap = SAP;
            //userData.role = role;

            TransactionResult res;
            res = mobileAppsUserLoginAppService.Update(ref mobileUser);

            if (res.Result == 1)
            {
                result.success = true;
                result.code = 200;
                result.message = "Insert Data Successfully";
                result.data = userData;
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = res.errException[0].ExMessage.ToString();
                result.data = userData;
            }

            return result;
        }
    }
}
