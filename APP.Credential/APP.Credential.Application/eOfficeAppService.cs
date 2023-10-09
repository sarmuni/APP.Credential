using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.Framework.Application;
using APP.Credential.Infrastructure;
using System.Data;

namespace APP.Credential.Application
{
    public class eOfficeAppService : AbstractAppService
    {
        public eOfficeAppService(AbstractUserProfile objUser)
            : base(objUser)
        {
        }

        public bool ValidUser(string UserID)
        {
            return new eOfficeDataAccess(DALInfo).ValidUser(UserID);
        }

        public DataTable GetEmployeebyGlobalID(string UserID)
        {
            return new eOfficeDataAccess(DALInfo).GetEmployeebyGlobalID(UserID);
        }
    }
}
