using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AddDepartmentDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public AddDepartmentDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public List<AddFacultyModel> GetAllFacultyName()
        {
            List<AddFacultyModel> addFacultyModels = new List<AddFacultyModel>();
            string query = String.Format("Select * from tblFaculty");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                AddFacultyModel addFacultyModel = new AddFacultyModel();
                addFacultyModel.ID = Convert.ToInt32(rdr[0]);
                addFacultyModel.Name = rdr[1].ToString();
                addFacultyModels.Add(addFacultyModel);
            }
            sqlConnection.Close();
            return addFacultyModels;
        }

        public bool IsDepartNameExist(DepartmentModel departmentModel)
         {
             bool isDepartmentNameExist = false;
            string query = String.Format("Select * from tblDepartment where name=@deptName");
            SqlParameter nameParameter = new SqlParameter("@deptName",departmentModel.DepartmentName);
            sqlCommand.Parameters.Add(nameParameter);
            sqlCommand.CommandText = query;

            sqlConnection.Open();
             SqlDataReader rdr = sqlCommand.ExecuteReader();
             while (rdr.Read())
             {
                 isDepartmentNameExist = true;
             }

            sqlConnection.Close();
            return isDepartmentNameExist;
        }


        public int SaveDepartmentName(DepartmentModel departmentModel)
        {
            string query = String.Format("Insert into tblDepartment values(@name,@facultyID)");
            sqlCommand.CommandText = query;
            SqlParameter nameParameter = new SqlParameter("@name",departmentModel.DepartmentName);
            sqlCommand.Parameters.Add(nameParameter);

            SqlParameter facultyIdParameter = new SqlParameter("@facultyID",departmentModel.FacultyID);
            sqlCommand.Parameters.Add(facultyIdParameter);
            

            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;
        }

        public List<ShowAllDepartmentInformationModel> ShowAllDepartmentInfo()
        {
            int serialNumber = 1;
            List<ShowAllDepartmentInformationModel> showAllDepartmentInformationModels = new List<ShowAllDepartmentInformationModel>();
            string query = String.Format(@"select tblDepartment.name , tblFaculty.facultyName
                                          from tblDepartment join tblFaculty 
                                          on tblDepartment.facultyId = tblFaculty.id");
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                ShowAllDepartmentInformationModel showAllDepartmentInformationModel = new ShowAllDepartmentInformationModel();
                showAllDepartmentInformationModel.Serial = serialNumber;
                showAllDepartmentInformationModel.DepartmentName = rdr[0].ToString();
                showAllDepartmentInformationModel.FacultyName = rdr[1].ToString();
                showAllDepartmentInformationModels.Add(showAllDepartmentInformationModel);
            }
            sqlConnection.Close();
            return showAllDepartmentInformationModels;
        }

        
    }
}