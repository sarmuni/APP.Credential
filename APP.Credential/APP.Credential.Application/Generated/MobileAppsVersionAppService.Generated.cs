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
public partial class MobileAppsVersionAppService : AbstractAppService
{
#region Collection
	public MobileAppsVersionAppService(AbstractUserProfile objUser) : base(objUser)
	{
	}


	public List<MobileAppsVersion> GetMobileAppsVersionList()
	{
		return new MobileAppsVersionDataAccess(DALInfo).GetMobileAppsVersionList();
	}


	public List<MobileAppsVersion> GetMobileAppsVersionListCustom(string Where = "", string OrderBy = "", int Start = 0, int Limit = 0)
	{
		return new MobileAppsVersionDataAccess(DALInfo).GetMobileAppsVersionListCustom(Where, OrderBy, Start, Limit);
	}


	public MobileAppsVersion GetMobileAppsVersionByMobileAppsVersionID(string IDMill,string Apps,string VersionName,string VersionCode)
	{
		return new MobileAppsVersionDataAccess(DALInfo).GetMobileAppsVersionByMobileAppsVersionID(IDMill,Apps,VersionName,VersionCode);
	}

	public TransactionResult Update(ref List<MobileAppsVersion> objList)
	{
		return new MobileAppsVersionDataAccess(DALInfo).Update(ref objList);
	}

	public TransactionResult Update(ref MobileAppsVersion item)
	{
		return new MobileAppsVersionDataAccess(DALInfo).Update(ref item);
	}

#endregion
}
}