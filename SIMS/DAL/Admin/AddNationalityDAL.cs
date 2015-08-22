using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AddNationalityDAL
    {
         private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public AddNationalityDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public bool IsNationalityExist(NationalityModel nationalityModel)
        {
            bool isNationalityExist = false;
            string query = String.Format("Select * from tblNationality where nationality=@nationality");
            SqlParameter nameParameter = new SqlParameter("@nationality", nationalityModel.Name);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isNationalityExist = true;
            }

            sqlConnection.Close();
            return isNationalityExist;
        }


        public int SaveNationality(NationalityModel nationalityModel)
        {
            string query = String.Format("Insert into tblNationality values(@name)");
            SqlParameter nameParameter = new SqlParameter("@name", nationalityModel.Name);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;
        }

        public List<NationalityModel> GetAllNationality()
        {
            int serialNumber = 1;
            List<NationalityModel> nationalityModels = new List<NationalityModel>();
            string query = String.Format("Select * from tblNationality");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                NationalityModel nationalityModel = new NationalityModel();
                nationalityModel.ID = serialNumber;
                nationalityModel.Name = rdr[1].ToString();
                nationalityModels.Add(nationalityModel);
                serialNumber++;
            }
            sqlConnection.Close();
            return nationalityModels;
        }
    }
}