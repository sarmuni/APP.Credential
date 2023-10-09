using APP.Framework.Application;
using APP.Framework.Infrastructure;

using APP.Credential.Domain;
using APP.Credential.Infrastructure;
using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace APP.Credential.Application
{
    [DebuggerStepThrough()]
    public partial class MsUserAppService : AbstractAppService
    {
        #region Collection
        public MsUserAppService(AbstractUserProfile objUser) : base(objUser)
        {
        }


        public List<MsUser> GetMsUserList()
        {
            return new MsUserDataAccess(DALInfo).GetMsUserList();
        }


        public List<MsUser> GetMsUserListCustom(string Where, string OrderBy, int Start, int Limit)
        {
            return new MsUserDataAccess(DALInfo).GetMsUserListCustom(Where, OrderBy, Start, Limit);
        }


        public MsUser GetMsUserByMsUserID(string ModuleID, string UserID, string UserRoleID, string Area)
        {
            return new MsUserDataAccess(DALInfo).GetMsUserByMsUserID(ModuleID, UserID, UserRoleID, Area);
        }

        public TransactionResult Update(ref List<MsUser> objList)
        {
            return new MsUserDataAccess(DALInfo).Update(ref objList);
        }

        public TransactionResult Update(ref MsUser item)
        {
            return new MsUserDataAccess(DALInfo).Update(ref item);
        }

        #endregion
    }
}