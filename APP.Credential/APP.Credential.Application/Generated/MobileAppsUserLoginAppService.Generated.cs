using APP.Framework.Application;
using APP.Framework.Infrastructure;

using APP.Credential.Domain;
using APP.Credential.Domain.Dto;
using APP.Credential.Infrastructure;
using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace APP.Credential.Application
{
[DebuggerStepThrough()]
public partial class MobileAppsUserLoginAppService : AbstractAppService
{
#region Collection
	public MobileAppsUserLoginAppService(AbstractUserProfile objUser) : base(objUser)
	{
	}


	public List<MobileAppsUserLogin> GetMobileAppsUserLoginList()
	{
		return new MobileAppsUserLoginDataAccess(DALInfo).GetMobileAppsUserLoginList();
	}


	public List<MobileAppsUserLogin> GetMobileAppsUserLoginListCustom(string Where = "", string OrderBy = "", int Start = 0, int Limit = 0)
	{
		return new MobileAppsUserLoginDataAccess(DALInfo).GetMobileAppsUserLoginListCustom(Where, OrderBy, Start, Limit);
	}


	public MobileAppsUserLogin GetMobileAppsUserLoginByMobileAppsUserLoginID(string IDMill,string UserID,string Apps)
	{
		return new MobileAppsUserLoginDataAccess(DALInfo).GetMobileAppsUserLoginByMobileAppsUserLoginID(IDMill,UserID,Apps);
	}

	public TransactionResult Update(ref List<MobileAppsUserLogin> objList)
	{
		return new MobileAppsUserLoginDataAccess(DALInfo).Update(ref objList);
	}

	public TransactionResult Update(ref MobileAppsUserLogin item)
	{
		return new MobileAppsUserLoginDataAccess(DALInfo).Update(ref item);
	}

#endregion
}
}