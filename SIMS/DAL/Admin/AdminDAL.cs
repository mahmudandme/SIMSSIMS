using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class AdminDAL
    {
        public bool IsAdminExist(AdminModel adminModel)
        {
            bool isAdminExist = false;
             string query = String.Format(@"select * from tblAdmin where name=@name and phone=@phone 
             and email=@email");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", adminModel.Name);
                    command.Parameters.AddWithValue("@phone", adminModel.Phone);
                    command.Parameters.AddWithValue("@email", adminModel.Email);                  
                   
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        isAdminExist = true;
                    }
                    connection.Close();
                }
            }
            return isAdminExist;
        }

        public int SaveAdminInformation(AdminModel adminModel)
        {
            int rowsInserted = 0;
            string query = String.Format(@"insert into tblAdmin values(@name,@phone,@email, 
                                          @adminId, @salt, @password, @type)");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", adminModel.Name);
                    command.Parameters.AddWithValue("@phone", adminModel.Phone);
                    command.Parameters.AddWithValue("@email", adminModel.Email);
                    command.Parameters.AddWithValue("@adminId", adminModel.AdminId);
                    command.Parameters.AddWithValue("@salt", adminModel.Salt);
                    command.Parameters.AddWithValue("@password", adminModel.Password);
                    command.Parameters.AddWithValue("@type", adminModel.Type);

                    connection.Open();
                   rowsInserted = command.ExecuteNonQuery();                    
                    connection.Close();
                }
            }
            return rowsInserted;
        }

        public List<AdminModel> GetAdminInformationByLastIdentity()
        {
            List<AdminModel> adminModels = new List<AdminModel>();

            // int lastIdentity = GetLastIdentityOfAddedStudent();
            string query = String.Format("SpGetAddedAdminInformation");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        AdminModel adminModel = new AdminModel();
                        adminModel.Name = rdr[0].ToString();
                        adminModel.Phone = rdr[1].ToString();
                        adminModel.Email = rdr[2].ToString();
                        adminModel.AdminId = rdr[3].ToString();                      
                        if (HttpContext.Current.Session["adminPassword"] != null)
                        {
                            adminModel.OnlyPassword = HttpContext.Current.Session["adminPassword"].ToString();
                        }
                        adminModels.Add(adminModel);
                    }
                    connection.Close();

                }
            }
            return adminModels;
        }

        public List<AdminModel> GetAllAdmin()
        {
           List<AdminModel> adminModels = new List<AdminModel>();
            string query = String.Format(@"select name,phone,email from tblAdmin");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {                    
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        AdminModel adminModel = new AdminModel();
                        adminModel.Name = rdr[0].ToString();
                        adminModel.Phone = rdr[1].ToString();
                        adminModel.Email = rdr[2].ToString();
                        adminModels.Add(adminModel);
                    }
                    connection.Close();
                }
            }
            return adminModels;
        }

       public LoginModel GetLoginInformation(string id1, string email1)
        {
            LoginModel loginModel = null;
            string query = String.Format("Select * from tblLogin where id=@id and email=@email");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id",id1);
                    command.Parameters.AddWithValue("@email", email1);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        loginModel =  new LoginModel();
                        loginModel.Salt = rdr[0].ToString();
                        loginModel.Hash = rdr[1].ToString();
                        loginModel.ID = rdr[2].ToString();
                        loginModel.Email = rdr[3].ToString();
                        loginModel.Type = Convert.ToInt32(rdr[4]);
                        loginModel.Name = rdr[5].ToString();

                    }
                    connection.Close();
                }
            }
            return loginModel;
        }

       public bool IsRegistrationPermissionExist(RegistrationPermissionModel registrationPermissionModel)
        {
            bool isRegistrationPermissionExist = false;
            string query = String.Format(@"Select * from tblRegistrationPermission where deptId=@deptId and sessionId=@sessionId and yearTermId=@yearTermId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();                    
                    command.Parameters.AddWithValue("@deptId", registrationPermissionModel.DeptId);
                    command.Parameters.AddWithValue("@sessionId", registrationPermissionModel.studentId);
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
           int rowsInserted = 0;
           string query = String.Format(@"insert into tblRegistrationPermission values(@deptId, @sessionId, @yearTermId");
           using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
           {
               using (SqlCommand command = new SqlCommand(query, connection))
               {
                   command.Parameters.Clear();                   
                   command.Parameters.AddWithValue("@deptId", registrationPermissionModel.DeptId);
                   command.Parameters.AddWithValue("@sessionId", registrationPermissionModel.studentId);
                   command.Parameters.AddWithValue("@yearTermId", registrationPermissionModel.YearTermId);
                   connection.Open();
                   rowsInserted = command.ExecuteNonQuery();
                   connection.Close();
               }
           }
           return rowsInserted;
       }

       public int GetMaxValueOfYearTermIdFromRegPermission(int deptId, int sessionId)
        {
            int maxYearTermValue = 0;
            string query = String.Format("Select COUNT(yearTermId) from tblRegistrationPermission where deptId=@deptId and sessionId=@sessionId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId",deptId);
                    command.Parameters.AddWithValue("@sessionId",sessionId);
                   
                    connection.Open();                                                                               
                        maxYearTermValue = Convert.ToInt32(command.ExecuteScalar());                                                                                                                               
                    connection.Close();
                }
            }
            return maxYearTermValue;
        }

      

       

    }
}