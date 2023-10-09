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
public partial class MobileAppsDeviceIDAppService : AbstractAppService
{
#region Collection
	public MobileAppsDeviceIDAppService(AbstractUserProfile objUser) : base(objUser)
	{
	}


	public List<MobileAppsDeviceID> GetMobileAppsDeviceIDList()
	{
		return new MobileAppsDeviceIDDataAccess(DALInfo).GetMobileAppsDeviceIDList();
	}


	public List<MobileAppsDeviceID> GetMobileAppsDeviceIDListCustom(string Where = "", string OrderBy = "", int Start = 0, int Limit = 0)
	{
		return new MobileAppsDeviceIDDataAccess(DALInfo).GetMobileAppsDeviceIDListCustom(Where, OrderBy, Start, Limit);
	}


	public MobileAppsDeviceID GetMobileAppsDeviceIDByMobileAppsDeviceIDID(string IDMill,string DeviceID)
	{
		return new MobileAppsDeviceIDDataAccess(DALInfo).GetMobileAppsDeviceIDByMobileAppsDeviceIDID(IDMill,DeviceID);
	}

	public TransactionResult Update(ref List<MobileAppsDeviceID> objList)
	{
		return new MobileAppsDeviceIDDataAccess(DALInfo).Update(ref objList);
	}

	public TransactionResult Update(ref MobileAppsDeviceID item)
	{
		return new MobileAppsDeviceIDDataAccess(DALInfo).Update(ref item);
	}

#endregion
}
}