using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SIMS.Models;

namespace SIMS.DAL.Admin
{
    public class ResultDAL
    {
        public List<DepartmentModel> GetAllDepartmentId()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            string query = String.Format(@"select deptId from tblStudentSemisterRegistration");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                       DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DeptID = Convert.ToInt32(rdr[0]);
                        departmentModels.Add(departmentModel);
                    }
                    connection.Close();
                }
            }
            return departmentModels;
        }

        public List<DepartmentModel> GetAllDepartmentName(List<DepartmentModel> departmentModelsParameter)
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            string query = String.Format(@"select id,name from tblDepartment where id=@deptId");

            foreach (DepartmentModel department in departmentModelsParameter)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@deptId",department.DeptID);
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
            }
            
            return departmentModels;
        }

        public List<SessionMedel> GetAllSessionIdByDepetId(int deptId)
        {
            List<SessionMedel> sessionMedels = new List<SessionMedel>();
            string query = String.Format(@"select sessionId from tblStudentSemisterRegistration where deptId=@deptId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId", deptId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SessionMedel sessionMedel = new SessionMedel();
                        sessionMedel.ID = Convert.ToInt32(rdr[0]);
                        sessionMedels.Add(sessionMedel);
                    }
                    connection.Close();
                }
            }
            return sessionMedels;
        }
        public List<SessionMedel> GetAllSessionBySessionId(List<SessionMedel> sessionMedelsParameter)
        {
            List<SessionMedel> sessionMedels = new List<SessionMedel>();
            string query = String.Format(@"select * from tblSession where id=@sessionId");
            foreach (SessionMedel session in sessionMedelsParameter)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@sessionId", session.ID);
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
            }
            return sessionMedels;
        }

        public List<YearTermModel> GetAllYearTermIdBysessionId(int sessionId)
        {
            List<YearTermModel> yearTermModels = new List<YearTermModel>();
            string query = String.Format(@"select yearTermId from tblStudentSemisterRegistration where sessionId=@sessionId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@sessionId",sessionId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        YearTermModel yearTermModel = new YearTermModel();
                        yearTermModel.ID = Convert.ToInt32(rdr[0]);
                        yearTermModels.Add(yearTermModel);
                    }
                    connection.Close();
                }
            }
            return yearTermModels;
        }
        public List<YearTermModel> GetAllYearTermByYearTermId(List<YearTermModel> yearTermModelsParameter)
        {
            List<YearTermModel> yearTermModels = new List<YearTermModel>();
            string query = String.Format(@"select * from tblYearTerm where id=@yearTermId");
            foreach (YearTermModel yearTerm in yearTermModelsParameter)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@yearTermId", yearTerm.ID);
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
            }
            return yearTermModels;
        }

        public List<StudentModel> GetAllStudentIdByDeptIdSessionIdYearTermId(int deptId, int sessionId, int yearTermId)
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            string query = String.Format(@"select studentId from tblStudentSemisterRegistration where deptId=@deptId and sessionId=@sessionId and yearTermId=@yearTermId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId", deptId);
                    command.Parameters.AddWithValue("@sessionId",sessionId);
                    command.Parameters.AddWithValue("@yearTermId",yearTermId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.ID = rdr[0].ToString();
                        studentModels.Add(studentModel);
                    }
                    connection.Close();
                }
            }
            return studentModels;
        }

        public List<CourseModel> GetAllCourseByDeptIdYearTermId(int deptId, int yearTermId)
        {
            List<CourseModel> courseModels = new List<CourseModel>();
            string query = String.Format(@"Select courseCode from tblCourse where deptId=@deptId and yearTermId=@yearTermId");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@deptId",deptId);
                    command.Parameters.AddWithValue("@yearTermId", yearTermId);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        CourseModel courseModel = new CourseModel();
                        courseModel.CourseCode = rdr[0].ToString();
                        courseModels.Add(courseModel);
                    }
                    connection.Close();
                }
            }
            return courseModels;
        }

        public List<GPAModel> GetAllGPA()
        {
            List<GPAModel> gpaModels = new List<GPAModel>();
            string query = String.Format(@"Select * from tblGpa");
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {                    
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        GPAModel gpaModel = new GPAModel();
                        gpaModel.GPA = Convert.ToDecimal(rdr[2]);
                        gpaModel.GPAType = rdr[3].ToString();
                        gpaModels.Add(gpaModel);
                    }
                    connection.Close();
                }
            }
            return gpaModels;
        }
    }
}