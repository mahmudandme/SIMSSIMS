using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AddFacultyDAL
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;

        public AddFacultyDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public bool IsFacultyNameExist(AddFacultyModel addFacultyModel)
        {
            bool isFacultyNameExist = false;
            string query = String.Format("Select * from tblFaculty where facultyName=@facultyName");
            SqlParameter nameParameter = new SqlParameter("@facultyName",addFacultyModel.Name);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                isFacultyNameExist = true;
            }

            sqlConnection.Close();
            return isFacultyNameExist;
        }


        public int SaveDepartmentName(AddFacultyModel addFacultyModel)
        {
            string query = String.Format("Insert into tblFaculty values(@name)");
            SqlParameter nameParameter = new SqlParameter("@name", addFacultyModel.Name);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;
        }
        // hv h vg


        public List<AddFacultyModel> GetAllFaculty()
        {
            int serialNumber = 1;
            List<AddFacultyModel> addFacultyModels = new List<AddFacultyModel>();
            string query = String.Format("Select * from tblFaculty");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                AddFacultyModel addFacultyModel = new AddFacultyModel();
                addFacultyModel.ID = serialNumber;
                addFacultyModel.Name = rdr[1].ToString();
                addFacultyModels.Add(addFacultyModel);
                serialNumber++;
            }
            sqlConnection.Close();
            return addFacultyModels;
        }


        public int DeleteFaculty(AddFacultyModel addFacultyModel)
        {
            
           
            string query = String.Format("Delete from tblFaculty where facultyName=@facultyName1");
            sqlCommand.CommandText = query;

            SqlParameter facultyName1Parameter = new SqlParameter("@facultyName1",addFacultyModel.Name);
            sqlCommand.Parameters.Add(facultyName1Parameter);
            sqlConnection.Open();
            int rowsDelated = sqlCommand.ExecuteNonQuery();          
            sqlConnection.Close();
            return rowsDelated;
        }




    }
}