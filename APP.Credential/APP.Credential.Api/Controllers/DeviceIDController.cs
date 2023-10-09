using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APP.Credential.Domain;
using APP.Framework;
using System.Web;
using System.Data;
using APP.Credential.Application;
using APP.Framework.Infrastructure;

namespace APP.Credential.Api.Controllers
{
    public class DeviceIDController : ApiController
    {
        private MobileAppsDeviceIDAppService mobileAppsDeviceIDAppService;
        UserProfile usr = new UserProfile
        {
            GlobalID = "System",
            ApplicationMode = Enumeration.ApplicationMode.Production,
            IPAddress = "127.0.0.1",
            CoverageArea = "IKS"
        };


        [HttpGet]
        public ResultDeviceID Get()
        {
            mobileAppsDeviceIDAppService = new MobileAppsDeviceIDAppService(usr);
            ResultDeviceID result = new ResultDeviceID();
            DeviceData device = new DeviceData();

            String deviceId;
            var httpRequest = HttpContext.Current.Request;
            deviceId = httpRequest["deviceId"];

            MobileAppsDeviceID deviceID = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDByMobileAppsDeviceIDID(usr.CoverageArea, deviceId);
            if(deviceID != null)
            {
                device.deviceID = deviceID.DeviceID;

                result.success = true;
                result.code = 200;
                result.message = "Data Found";
                result.data = device;
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Data Not Found";
                result.data = device;
            }

            return result;
        }

        [HttpPost]
        public ResultDeviceID Post()
        {
            mobileAppsDeviceIDAppService = new MobileAppsDeviceIDAppService(usr);
            ResultDeviceID result = new ResultDeviceID();
            DeviceData device = new DeviceData();

            String deviceId;
            var httpRequest = HttpContext.Current.Request;
            deviceId = httpRequest["deviceId"];

            MobileAppsDeviceID deviceID = mobileAppsDeviceIDAppService.GetMobileAppsDeviceIDByMobileAppsDeviceIDID(usr.CoverageArea, deviceId);
            if (deviceID == null)
            {
                deviceID = new MobileAppsDeviceID();
                deviceID.DeviceID = deviceId;
                deviceID.IDMill = usr.CoverageArea;

                device.deviceID = deviceId;
            }

            TransactionResult res;
            res = mobileAppsDeviceIDAppService.Update(ref deviceID);

            if (res.Result == 1)
            {
                result.success = true;
                result.code = 200;
                result.message = "Insert Data Successfully";
                result.data = device;
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = res.errException[0].ExMessage.ToString();
                result.data = device;
            }

            return result;
        }
    }
}
