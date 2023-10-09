using APP.Framework;
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
using System.IO;

namespace APP.Credential.Api.Controllers
{
    public class MobileVersionController : ApiController
    {
        private MobileAppsVersionAppService mobileAppsVersionAppService;
        UserProfile usr = new UserProfile
        {
            GlobalID = "System",
            ApplicationMode = Enumeration.ApplicationMode.Production,
            IPAddress = "127.0.0.1",
            CoverageArea = "IKS"
        };


        [HttpGet]
        public ResultMobileVersion Get()
        {
            mobileAppsVersionAppService = new MobileAppsVersionAppService(usr);
            ResultMobileVersion result = new ResultMobileVersion();
            VersionData version = new VersionData();

            String apps;
            var httpRequest = HttpContext.Current.Request;
            apps = httpRequest["apps"];

            List<MobileAppsVersion> mobileVersion = mobileAppsVersionAppService.GetMobileAppsVersionListCustom("IDMill='"+usr.CoverageArea+"' AND ActiveFlag='Y' AND Apps='"+apps+"'","ReleaseDate DESC");
            if(mobileVersion.Count > 0)
            {
                version.downloadUrl = mobileVersion[0].DownloadURL;
                version.releaseDate = Convert.ToDateTime(mobileVersion[0].ReleaseDate);
                version.versionCode = mobileVersion[0].VersionCode;
                version.versionName = mobileVersion[0].VersionName;

                result.success = true;
                result.code = 200;
                result.message = "Data Found";
                result.data = version;
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Data Not Found";
                result.data = version;
            }

            return result;
        }

        [HttpPost]
        public ResultMobileVersion Post()
        {
            mobileAppsVersionAppService = new MobileAppsVersionAppService(usr);
            ResultMobileVersion result = new ResultMobileVersion();
            VersionData version = new VersionData();

            String apps, versionName, versionCode, downloadURL, remark;

            var httpRequest = HttpContext.Current.Request;
            apps = httpRequest["apps"];
            versionName = httpRequest["versionName"];
            versionCode = httpRequest["versionCode"];
            downloadURL = httpRequest["downloadURL"];
            remark = httpRequest["remark"];

            version.releaseDate = DateTime.Now;
            version.versionCode = versionCode;
            version.versionName = versionName;
            version.downloadUrl = "";

            String dirFile = "", dirSave = "";
            
            string fileName = "", fileExt = "";

            if (httpRequest.Files.Count > 0)
            {
                HttpPostedFile file = httpRequest.Files["file"];

                if (file != null && file.ContentLength > 0)
                {
                    // Process the uploaded file here.
                    fileName = file.FileName;
                    fileExt = Path.GetExtension(fileName);
                    byte[] fileData = new byte[file.ContentLength];
                    file.InputStream.Read(fileData, 0, file.ContentLength);

                    //klo data image ada
                    dirFile = @"E:\Userfiles\apk.userfiles\";

                    bool exists = System.IO.Directory.Exists(dirFile);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(dirFile);

                    dirFile = dirFile + apps + "_" + versionCode + fileExt;
                    dirSave = downloadURL + apps + "_" + versionCode + fileExt;

                    // Perform actions like saving the file to a server location or database.
                    File.WriteAllBytes(dirFile, fileData);

                    version.downloadUrl = dirSave;

                }
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "File upload not found";
                result.data = version;

                return result;
            }

            TransactionResult transRes;

            MobileAppsVersion mobileVersion = mobileAppsVersionAppService.GetMobileAppsVersionByMobileAppsVersionID(usr.CoverageArea, apps, versionName, versionCode);
            if (mobileVersion == null)
            {
                mobileVersion = new MobileAppsVersion();
                mobileVersion.DownloadURL = dirSave;
                mobileVersion.ReleaseDate = DateTime.Now;
                mobileVersion.VersionCode = versionCode;
                mobileVersion.VersionName = versionName;
                mobileVersion.Apps = apps;
                mobileVersion.IDMill = usr.CoverageArea;
                mobileVersion.Remark = remark;

            }
            else
            {
                mobileVersion.DownloadURL = downloadURL;
                mobileVersion.ReleaseDate = DateTime.Now;
                mobileVersion.VersionCode = versionCode;
                mobileVersion.VersionName = versionName;
                mobileVersion.Remark = remark;
            }

            transRes = mobileAppsVersionAppService.Update(ref mobileVersion);

            if(transRes.Result == 1)
            {
                result.success = true;
                result.code = 200;
                result.message = "Upload data successfully";
                result.data = version;
            }
            else
            {
                result.success = false;
                result.code = 200;
                result.message = "Upload data failed";
                result.data = version;
            }            

            return result;
        }
    }
}
