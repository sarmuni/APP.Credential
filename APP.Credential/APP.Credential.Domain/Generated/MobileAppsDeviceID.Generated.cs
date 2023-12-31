﻿using APP.Framework.Domain;

using System;

using System.Diagnostics;

/*Generated by .NET Class Generator Tools*/

namespace APP.Credential.Domain
{
[DebuggerStepThrough()]public partial class MobileAppsDeviceID : AbstractTable
{
#region Data Member
	private string _IDMill;
	private string _DeviceID;
	private string _CrtUsrID;
	private DateTime _TsCrt;
	private string _ModUsrID;
	private DateTime _TsMod;
	private string _ActiveFlag = "Y";
#endregion

#region Default Value
	public MobileAppsDeviceID()
	{
	}
#endregion


#region Properties
	public string IDMill
	{
		get
		{
			return _IDMill;
		}
		set
		{
			_IDMill = value;
			Modify();
		}
	}

	public string DeviceID
	{
		get
		{
			return _DeviceID;
		}
		set
		{
			_DeviceID = value;
			Modify();
		}
	}

	public string CrtUsrID
	{
		get
		{
			return _CrtUsrID;
		}
		set
		{
			_CrtUsrID = value;
			Modify();
		}
	}

	public DateTime TsCrt
	{
		get
		{
			return _TsCrt;
		}
		set
		{
			_TsCrt = value;
			Modify();
		}
	}

	public string ModUsrID
	{
		get
		{
			return _ModUsrID;
		}
		set
		{
			_ModUsrID = value;
			Modify();
		}
	}

	public DateTime TsMod
	{
		get
		{
			return _TsMod;
		}
		set
		{
			_TsMod = value;
			Modify();
		}
	}

	public string ActiveFlag
	{
		get
		{
			return _ActiveFlag;
		}
		set
		{
			_ActiveFlag = value;
			Modify();
		}
	}

#endregion

}
}