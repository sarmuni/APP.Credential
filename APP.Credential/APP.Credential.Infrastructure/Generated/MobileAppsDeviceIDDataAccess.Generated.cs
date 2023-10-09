﻿//Generated by .NET Class Generator Tools

using System;
using System.Data;
using System.Data.SqlClient;
using APP.Framework.Infrastructure;

using APP.Credential.Domain;
using System.Collections.Generic;

namespace APP.Credential.Infrastructure
{
public partial class MobileAppsDeviceIDDataAccess
{	private DAL DALInfo;

	public MobileAppsDeviceIDDataAccess(DAL objDAL)
	{
		DALInfo = objDAL;
		DALInfo.ConnectionString = new Connection(DALInfo).ConnectionString(DALInfo.ApplicationMode);
	}

	private static T Mapper<T>(object obj)
	{
		T val = default(T);
		if (obj != DBNull.Value)
		{
			val = (T) obj;
		}
		return val;
	}



#region Standard
public MobileAppsDeviceID GetMobileAppsDeviceIDByMobileAppsDeviceIDID(string IDMill,string DeviceID)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsDeviceID", conn);
	MobileAppsDeviceID objTbl = new MobileAppsDeviceID();
	cmd.CommandType = CommandType.StoredProcedure;

	cmd.Parameters.AddWithValue("@IDMill",IDMill);	cmd.Parameters.AddWithValue("@DeviceID",DeviceID);
	SqlDataReader da = default(SqlDataReader);
	try
	{
		cmd.Connection.Open();
		da = cmd.ExecuteReader();

		if (da.HasRows)
		{
			objTbl = MoveDataToCollection(da)[0];
		}
		else
		{
			return null;
		}
	}
	catch (Exception ex)
	{
		throw ex;
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return objTbl;
}


public List<MobileAppsDeviceID> GetMobileAppsDeviceIDList()
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsDeviceIDList", conn);
	List<MobileAppsDeviceID> mobileAppsDeviceIDList = new List<MobileAppsDeviceID>();
	cmd.CommandType = CommandType.StoredProcedure;

	SqlDataReader da = default(SqlDataReader);
	try
	{
		cmd.Connection.Open();
		da = cmd.ExecuteReader();

		if (da.HasRows)
		{
			mobileAppsDeviceIDList = MoveDataToCollection(da);
		}
		else
		{
			return mobileAppsDeviceIDList;
		}
	}
	catch (Exception ex)
	{
		throw ex;
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return mobileAppsDeviceIDList;
}


public List<MobileAppsDeviceID> GetMobileAppsDeviceIDListCustom(string Where, string OrderBy, int Start, int Limit)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsDeviceIDListCustom", conn);
	SqlParameter orderBy = new SqlParameter("@OrderBy", SqlDbType.VarChar);
	SqlParameter where = new SqlParameter("@Where", SqlDbType.VarChar);
	SqlParameter start = new SqlParameter("@Start", SqlDbType.Int);
	SqlParameter limit = new SqlParameter("@Limit", SqlDbType.VarChar);

	Start = (Start - 1) * Limit;

	where.Value = Where;
	orderBy.Value = OrderBy;
	start.Value = Start;
	limit.Value = Limit;

	cmd.Parameters.Add(where);
	cmd.Parameters.Add(orderBy);
	cmd.Parameters.Add(start);
	cmd.Parameters.Add(limit);

	List<MobileAppsDeviceID> mobileAppsDeviceIDList = new List<MobileAppsDeviceID>();
	cmd.CommandType = CommandType.StoredProcedure;

	SqlDataReader da = default(SqlDataReader);
	cmd.Connection.Open();
	da = cmd.ExecuteReader();

	try
	{
		if (da.HasRows)
		{
			if (Start == 0 && Limit == 0)
			{
				mobileAppsDeviceIDList = MoveDataToCollection(da, false);
			}
			else
			{
				mobileAppsDeviceIDList = MoveDataToCollection(da, true);
			}
		}
		else
		{
			return mobileAppsDeviceIDList;
		}
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return mobileAppsDeviceIDList;
}


private List<MobileAppsDeviceID> MoveDataToCollection(SqlDataReader MyReader,Boolean isCustom = false)
{
	List<MobileAppsDeviceID> mobileAppsDeviceIDList = new List<MobileAppsDeviceID>();
	while (MyReader.Read())
	{
		MobileAppsDeviceID objMobileAppsDeviceID = new MobileAppsDeviceID();
		objMobileAppsDeviceID.IDMill = MyReader["idmill"].ToString().Trim();
		objMobileAppsDeviceID.DeviceID = MyReader["deviceid"].ToString().Trim();
		objMobileAppsDeviceID.CrtUsrID = MyReader["crtusrid"].ToString().Trim();
		objMobileAppsDeviceID.TsCrt = Mapper<DateTime>(MyReader["tscrt"]);
		objMobileAppsDeviceID.ModUsrID = MyReader["modusrid"].ToString().Trim();
		objMobileAppsDeviceID.TsMod = Mapper<DateTime>(MyReader["tsmod"]);
		objMobileAppsDeviceID.ActiveFlag = MyReader["activeflag"].ToString().Trim();
		objMobileAppsDeviceID.RowState = DataRowState.Unchanged;

		if (isCustom == true)
		{
			objMobileAppsDeviceID.RowNumber = Convert.ToInt64(MyReader["RowNumber"]);
			objMobileAppsDeviceID.TotalRecord = Convert.ToInt64(MyReader["TotalRecord"]);
		}
		mobileAppsDeviceIDList.Add(objMobileAppsDeviceID);
	}
	return mobileAppsDeviceIDList;
}


public TransactionResult Update(ref List<MobileAppsDeviceID> objList)
{
	List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
	TransactionDB TransDB = new TransactionDB(DALInfo);
	TransactionResult ObjTransResult = default(TransactionResult);

	GetBatchQueryUpdate(objList,ref ArraySQLCmd);

	ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

	if (ObjTransResult.Result == 1)
	{
		objList = AcceptChanges(ref objList);
	}

	return ObjTransResult;
}

public TransactionResult Update(ref MobileAppsDeviceID item)
{
	List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
	TransactionDB TransDB = new TransactionDB(DALInfo);
	TransactionResult ObjTransResult = default(TransactionResult);

	GetSingleQueryUpdate(item,ref ArraySQLCmd);

	ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

	if (ObjTransResult.Result == 1 && !item.RowState.Equals(DataRowState.Deleted))
	{
		item.RowState = DataRowState.Unchanged;
	}

	return ObjTransResult;
}

public List<MobileAppsDeviceID> AcceptChanges(ref List<MobileAppsDeviceID> objList)
{
	List<MobileAppsDeviceID> DataBindCol = new List<MobileAppsDeviceID>();

	foreach (MobileAppsDeviceID item in objList)
	{
		if (item.RowState != DataRowState.Deleted)
		{
			item.RowState = DataRowState.Unchanged;
			DataBindCol.Add(item);
		}
	}
	objList= new List<MobileAppsDeviceID>();
	objList = DataBindCol;
	return DataBindCol;
}

public void GetSingleQueryUpdate(MobileAppsDeviceID item, ref List<SqlCommand> ArraySQLCmd)
{
		MobileAppsDeviceID itm = item;
	DALInfo.AssignedInfo(ref itm);
	UpdateQuery(itm, ArraySQLCmd);
}

public void GetBatchQueryUpdate(List<MobileAppsDeviceID> objDomain, ref List<SqlCommand> ArraySQLCmd)
{
	foreach (MobileAppsDeviceID item in objDomain)
	{
		MobileAppsDeviceID itm = item;
		DALInfo.AssignedInfo(ref itm);
		UpdateQuery(itm, ArraySQLCmd);
	}
}

public void UpdateQuery(MobileAppsDeviceID item, List<SqlCommand> ArraySQLCmd)
{
	SqlCommand cmd = null;
	if (item.RowState == DataRowState.Added)
	{
		cmd = new SqlCommand("up_InsertMobileAppsDeviceID");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@deviceid", SqlDbType.VarChar, 500).Value = item.DeviceID;
		cmd.Parameters.Add("@crtusrid", SqlDbType.VarChar, 20).Value = item.CrtUsrID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 20).Value = item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Modified)
	{
		cmd = new SqlCommand("up_UpdateMobileAppsDeviceID");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@deviceid", SqlDbType.VarChar, 500).Value = item.DeviceID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 20).Value = item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Deleted)
	{
		cmd = new SqlCommand("up_DeleteMobileAppsDeviceID");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@deviceid", SqlDbType.VarChar, 500).Value = item.DeviceID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 20).Value = item.ModUsrID;
	}

	if (cmd != null)
	{
		ArraySQLCmd.Add(cmd);
	}
}


#endregion
}
}