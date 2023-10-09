﻿//Generated by .NET Class Generator Tools

using System;
using System.Data;
using System.Data.SqlClient;
using APP.Framework.Infrastructure;

using APP.Credential.Domain;
using System.Collections.Generic;

namespace APP.Credential.Infrastructure
{
public partial class MobileAppsUserLoginDataAccess
{	private DAL DALInfo;

	public MobileAppsUserLoginDataAccess(DAL objDAL)
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
public MobileAppsUserLogin GetMobileAppsUserLoginByMobileAppsUserLoginID(string IDMill,string UserID,string Apps)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsUserLogin", conn);
	MobileAppsUserLogin objTbl = new MobileAppsUserLogin();
	cmd.CommandType = CommandType.StoredProcedure;

	cmd.Parameters.AddWithValue("@IDMill",IDMill);	cmd.Parameters.AddWithValue("@UserID",UserID);	cmd.Parameters.AddWithValue("@Apps",Apps);
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


public List<MobileAppsUserLogin> GetMobileAppsUserLoginList()
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsUserLoginList", conn);
	List<MobileAppsUserLogin> mobileAppsUserLoginList = new List<MobileAppsUserLogin>();
	cmd.CommandType = CommandType.StoredProcedure;

	SqlDataReader da = default(SqlDataReader);
	try
	{
		cmd.Connection.Open();
		da = cmd.ExecuteReader();

		if (da.HasRows)
		{
			mobileAppsUserLoginList = MoveDataToCollection(da);
		}
		else
		{
			return mobileAppsUserLoginList;
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

	return mobileAppsUserLoginList;
}


public List<MobileAppsUserLogin> GetMobileAppsUserLoginListCustom(string Where, string OrderBy, int Start, int Limit)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveMobileAppsUserLoginListCustom", conn);
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

	List<MobileAppsUserLogin> mobileAppsUserLoginList = new List<MobileAppsUserLogin>();
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
				mobileAppsUserLoginList = MoveDataToCollection(da, false);
			}
			else
			{
				mobileAppsUserLoginList = MoveDataToCollection(da, true);
			}
		}
		else
		{
			return mobileAppsUserLoginList;
		}
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return mobileAppsUserLoginList;
}


private List<MobileAppsUserLogin> MoveDataToCollection(SqlDataReader MyReader,Boolean isCustom = false)
{
	List<MobileAppsUserLogin> mobileAppsUserLoginList = new List<MobileAppsUserLogin>();
	while (MyReader.Read())
	{
		MobileAppsUserLogin objMobileAppsUserLogin = new MobileAppsUserLogin();
		objMobileAppsUserLogin.IDMill = MyReader["idmill"].ToString().Trim();
		objMobileAppsUserLogin.UserID = MyReader["userid"].ToString().Trim();
		objMobileAppsUserLogin.Apps = MyReader["apps"].ToString().Trim();
		objMobileAppsUserLogin.FullName = MyReader["fullname"].ToString().Trim();
		objMobileAppsUserLogin.Role = MyReader["role"].ToString().Trim();
		objMobileAppsUserLogin.CrtUsrID = MyReader["crtusrid"].ToString().Trim();
		objMobileAppsUserLogin.TsCrt = Mapper<DateTime>(MyReader["tscrt"]);
		objMobileAppsUserLogin.ModUsrID = MyReader["modusrid"].ToString().Trim();
		objMobileAppsUserLogin.TsMod = Mapper<DateTime>(MyReader["tsmod"]);
		objMobileAppsUserLogin.ActiveFlag = MyReader["activeflag"].ToString().Trim();
		objMobileAppsUserLogin.RowState = DataRowState.Unchanged;

		if (isCustom == true)
		{
			objMobileAppsUserLogin.RowNumber = Convert.ToInt64(MyReader["RowNumber"]);
			objMobileAppsUserLogin.TotalRecord = Convert.ToInt64(MyReader["TotalRecord"]);
		}
		mobileAppsUserLoginList.Add(objMobileAppsUserLogin);
	}
	return mobileAppsUserLoginList;
}


public TransactionResult Update(ref List<MobileAppsUserLogin> objList)
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

public TransactionResult Update(ref MobileAppsUserLogin item)
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

public List<MobileAppsUserLogin> AcceptChanges(ref List<MobileAppsUserLogin> objList)
{
	List<MobileAppsUserLogin> DataBindCol = new List<MobileAppsUserLogin>();

	foreach (MobileAppsUserLogin item in objList)
	{
		if (item.RowState != DataRowState.Deleted)
		{
			item.RowState = DataRowState.Unchanged;
			DataBindCol.Add(item);
		}
	}
	objList= new List<MobileAppsUserLogin>();
	objList = DataBindCol;
	return DataBindCol;
}

public void GetSingleQueryUpdate(MobileAppsUserLogin item, ref List<SqlCommand> ArraySQLCmd)
{
		MobileAppsUserLogin itm = item;
	DALInfo.AssignedInfo(ref itm);
	UpdateQuery(itm, ArraySQLCmd);
}

public void GetBatchQueryUpdate(List<MobileAppsUserLogin> objDomain, ref List<SqlCommand> ArraySQLCmd)
{
	foreach (MobileAppsUserLogin item in objDomain)
	{
		MobileAppsUserLogin itm = item;
		DALInfo.AssignedInfo(ref itm);
		UpdateQuery(itm, ArraySQLCmd);
	}
}

public void UpdateQuery(MobileAppsUserLogin item, List<SqlCommand> ArraySQLCmd)
{
	SqlCommand cmd = null;
	if (item.RowState == DataRowState.Added)
	{
		cmd = new SqlCommand("up_InsertMobileAppsUserLogin");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20).Value = item.UserID;
		cmd.Parameters.Add("@apps", SqlDbType.VarChar, 20).Value = item.Apps;
		cmd.Parameters.Add("@fullname", SqlDbType.VarChar, 200).Value = item.FullName == null ? (object)DBNull.Value : item.FullName;
		cmd.Parameters.Add("@role", SqlDbType.VarChar, 10).Value = item.Role == null ? (object)DBNull.Value : item.Role;
		cmd.Parameters.Add("@crtusrid", SqlDbType.VarChar, 20).Value = item.CrtUsrID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 20).Value = item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Modified)
	{
		cmd = new SqlCommand("up_UpdateMobileAppsUserLogin");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20).Value = item.UserID;
		cmd.Parameters.Add("@apps", SqlDbType.VarChar, 20).Value = item.Apps;
		cmd.Parameters.Add("@fullname", SqlDbType.VarChar, 200).Value = item.FullName == null ? (object)DBNull.Value : item.FullName;
		cmd.Parameters.Add("@role", SqlDbType.VarChar, 10).Value = item.Role == null ? (object)DBNull.Value : item.Role;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 20).Value = item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Deleted)
	{
		cmd = new SqlCommand("up_DeleteMobileAppsUserLogin");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@idmill", SqlDbType.VarChar, 10).Value = item.IDMill;
		cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20).Value = item.UserID;
		cmd.Parameters.Add("@apps", SqlDbType.VarChar, 20).Value = item.Apps;
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