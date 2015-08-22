using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AddSessionDAL
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public AddSessionDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public bool IsSessionExist(SessionMedel sessionMedel)
        {
            bool isSessionExist = false;
            string query = String.Format("Select * from tblSession where name=@name");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.Clear();
                SqlParameter nameParameter = new SqlParameter("@name", sessionMedel.SessionValue);
                cmd.Parameters.Add(nameParameter);               
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    isSessionExist = true;
                }
                con.Close();
            }            
            return isSessionExist;
        }


        public int SaveSession(SessionMedel sessionMedel)
        {
            string query = String.Format("Insert into tblSession values(@sessionValue)");
            int rowsAffected = 0;           
            using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand(query,con1);
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@sessionValue", sessionMedel.SessionValue);
                con1.Open();                                
                rowsAffected = cmd1.ExecuteNonQuery();
                con1.Close();
                
            }
            return rowsAffected;
        }

        public List<SessionMedel> GetAllSession()
        {
            List<SessionMedel> sessionMedels = new List<SessionMedel>();
            string query = String.Format("spGetAllSession");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = query;
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataReader rdr = sqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    SessionMedel sessionMedel = new SessionMedel();
                    sessionMedel.ID = Convert.ToInt32(rdr[0]);
                    sessionMedel.SessionValue = rdr[1].ToString();
                    sessionMedels.Add(sessionMedel);
                }
                sqlConnection.Close();
            }
            return sessionMedels;
        }

    }
}