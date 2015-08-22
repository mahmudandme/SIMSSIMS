using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AddStudentDAL
    {        
        public List<GenderModel> GetAllGender()
        {
            List<GenderModel> genderModels = new List<GenderModel>();
            string query = String.Format("spGetAllGender");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {                    
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        GenderModel genderModel = new GenderModel();
                        genderModel.ID = Convert.ToInt32(rdr[0]);
                        genderModel.Gender = rdr[1].ToString();
                        genderModels.Add(genderModel);
                    }
                    connection.Close(); 
                }
                

            }
            return genderModels;
        }
        public List<YearTermModel> GetAllYearTerm()
        {
            List<YearTermModel> yearTermModels = new List<YearTermModel>();
            string query = String.Format("spGetAllYearTerm");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        YearTermModel yearTermModel = new YearTermModel();
                        yearTermModel.ID = Convert.ToInt32(rdr[0]);
                        yearTermModel.YearTerm = rdr[1].ToString();
                        yearTermModels.Add(yearTermModel);
                    }
                    connection.Close();
                }
            }
            return yearTermModels;
        }

        public List<DepartmentModel> GetAllDepartMent()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            string query = String.Format("spGetAllDepartment");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DeptID = Convert.ToInt32(rdr[0]);
                        departmentModel.DepartmentName = rdr[1].ToString();
                        departmentModels.Add(departmentModel);
                    }
                    connection.Close();
                }
            }
            return departmentModels;
        }

        public List<SessionMedel> GetAllSession()
        {
            List<SessionMedel> sessionMedels = new List<SessionMedel>();
            string query = String.Format("spGetAllSession");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SessionMedel sessionMedel = new SessionMedel();
                        sessionMedel.ID = Convert.ToInt32(rdr[0]);
                        sessionMedel.SessionValue = rdr[1].ToString();
                        sessionMedels.Add(sessionMedel);
                    }
                    connection.Close();
                }
            }
            return sessionMedels;
        }

        public bool IsStudentIdAndDeptIdExist(AddStudentModel addStudentModel)
        {
            bool isStudentIdAndDeptIdExist = false;
            string query = String.Format("spGetStudentByIdAndDeptId");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@studentId", addStudentModel.StudentId);
                    command.Parameters.AddWithValue("@deptId", addStudentModel.DeptId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        isStudentIdAndDeptIdExist = true;
                    }
                    command.Parameters.Clear();
                    connection.Close();                    
                }
            }
            return isStudentIdAndDeptIdExist;
        }

        public int SaveStudentInformation(AddStudentModel addStudentModel)
        {
            int rowsInserted = 0;
            string query = String.Format("spSaveNewStudentInformation");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId",addStudentModel.StudentId);
                    command.Parameters.AddWithValue("@studentName", addStudentModel.Name);
                    command.Parameters.AddWithValue("@phone", addStudentModel.Phone);
                    command.Parameters.AddWithValue("@email", addStudentModel.Email);
                    command.Parameters.AddWithValue("@presentAddress", addStudentModel.PresentAddress);
                    command.Parameters.AddWithValue("@permanentAddress", addStudentModel.PermanentAddress);
                    command.Parameters.AddWithValue("@genderId", addStudentModel.GenderId);
                    command.Parameters.AddWithValue("@nationality", addStudentModel.NationalityId);
                    command.Parameters.AddWithValue("@departmentId", addStudentModel.DeptId);
                    command.Parameters.AddWithValue("@sessionId", addStudentModel.SessionId);
                    command.Parameters.AddWithValue("@yearTermId", addStudentModel.YearTermId);
                    command.Parameters.AddWithValue("@salt", addStudentModel.Salt);
                    command.Parameters.AddWithValue("@password", addStudentModel.Password);
                    command.Parameters.AddWithValue("@type", addStudentModel.Type);
                    connection.Open();
                    rowsInserted = command.ExecuteNonQuery();                   
                    connection.Close();
                    command.Parameters.Clear();
                }
            }
            return rowsInserted;
        }        

        public List<GeneratedStudentModel> GetStudentInformationByLastIdentity()
        {
            List<GeneratedStudentModel> generatedStudentModels = new List<GeneratedStudentModel>();
            
           // int lastIdentity = GetLastIdentityOfAddedStudent();
            string query = String.Format("SpGetAddedStudentInformation");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneratedStudentModel generatedStudentModel = new GeneratedStudentModel();
                        generatedStudentModel.StudentName = rdr[0].ToString();
                        generatedStudentModel.StudentID = rdr[1].ToString();
                        generatedStudentModel.DepartmentName = rdr[2].ToString();
                        generatedStudentModel.Session = rdr[3].ToString();
                        generatedStudentModel.Email = rdr[4].ToString();
                        if (HttpContext.Current.Session["studentPassword"] != null)
                        {
                            generatedStudentModel.Password = HttpContext.Current.Session["studentPassword"].ToString();
                        }
                       generatedStudentModels.Add(generatedStudentModel); 
                    }
                    connection.Close();
                    
                }
            }
            return generatedStudentModels;
        }

        public List<ShowStudentInformationModel> GetStudentInformationById(string studentId, int departmentId)
        {
            List<ShowStudentInformationModel> showStudentInformationModels = new List<ShowStudentInformationModel>();
            string query = "";
            if (studentId == String.Empty)
            {
                query = String.Format("spGetStudentByDeptId");   
            }
            else
            {
                query = String.Format("spGetStudentByIdAndDeptId"); 
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                   
                    if (studentId ==String.Empty)
                    {
                        command.Parameters.AddWithValue("@deptId", departmentId);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);
                        command.Parameters.AddWithValue("@deptId", departmentId);
                    }
                    

                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        ShowStudentInformationModel showStudentInformationModel = new ShowStudentInformationModel();
                        showStudentInformationModel.StudentID = rdr[0].ToString();
                        showStudentInformationModel.StudentName = rdr[1].ToString();
                        showStudentInformationModel.Phone = rdr[2].ToString();
                        showStudentInformationModel.Email = rdr[3].ToString();
                        showStudentInformationModel.Gender = rdr[4].ToString();
                        showStudentInformationModel.Nationality = rdr[5].ToString();
                        showStudentInformationModel.DepartmentName = rdr[6].ToString();
                        showStudentInformationModel.Session = rdr[7].ToString();
                        showStudentInformationModel.YearTerm = rdr[8].ToString();
                        showStudentInformationModels.Add(showStudentInformationModel);
                    }
                    connection.Close();
                }
            }
            return showStudentInformationModels;
        }

        public bool IsRegistrationPermissionExist(RegistrationPermissionModel registrationPermissionModel)
        {
            string query = String.Format("Select * from tblRegistrationPermission where deptId=@deptId and sessionId=@sessionId and yearTermId=@yearTermId");
            bool isRegistrationPermissionExist = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId",registrationPermissionModel.DeptId);
                    command.Parameters.AddWithValue("@sessionId", registrationPermissionModel.SessionId);
                    command.Parameters.AddWithValue("@yearTermId", registrationPermissionModel.YearTermId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        isRegistrationPermissionExist = true;
                    }
                    connection.Close();
                }
            }
            return isRegistrationPermissionExist;
        }

        public int SaveRegistrationPermission(RegistrationPermissionModel registrationPermissionModel)
        {
            string query = String.Format("insert into tblRegistrationPermission values(@deptId, @sessionId, @yearTermId)");
            int rowsInserted = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId", registrationPermissionModel.DeptId);
                    command.Parameters.AddWithValue("@sessionId", registrationPermissionModel.SessionId);
                    command.Parameters.AddWithValue("@yearTermId", registrationPermissionModel.YearTermId);
                    connection.Open();
                    rowsInserted = command.ExecuteNonQuery();                    
                    connection.Close();
                }
            }
            return rowsInserted;
        }



    }
}