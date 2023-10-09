using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.Framework.Infrastructure;
using System.Data.SqlClient;
using System.Data;

namespace APP.Credential.Infrastructure
{
    public class eOfficeDataAccess
    {
        private DAL DALInfo;

        public eOfficeDataAccess(DAL objDAL)
        {
            DALInfo = objDAL;
            DALInfo.ConnectionString = new Connection(DALInfo).UserEmployeeConnectionString(DALInfo.ApplicationMode);
        }

        public bool ValidUser(string UserID)
        {
            bool isValid = false;
            using (SqlConnection con = new SqlConnection(DALInfo.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = "select TOP 1 * from user_registration.dbo.employee where active='Y' and id_user=@UserID;";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    var res = cmd.ExecuteScalar();
                    if (res != DBNull.Value && res != null) isValid = true;
                }
            }
            return isValid;
        }

        public DataTable GetEmployeebyGlobalID(string UserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(DALInfo.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = "select * from user_registration.dbo.employee where active='Y' and id_user=@UserID;";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
