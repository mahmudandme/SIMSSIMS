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
    public class TeacherDAL
    {
        public bool IsTeacherNameAndEmailExist(string name, string email)
        {
            bool IsExist = false;
            string query = String.Format("Select * from tblTeacher where name=@name and email=@email");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name",name );
                    command.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        IsExist = true;
                    }
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
            return IsExist;
        }

        //public int SaveTeacherInformation(TeacherModel teacherModel)
        //{
        //    int rowsInserted = 0;
        //    string query = String.Format("spSaveTeacherInformation");

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@studentId", teacherModel.);
        //            command.Parameters.AddWithValue("@studentName", addStudentModel.Name);
        //            command.Parameters.AddWithValue("@phone", addStudentModel.Phone);
        //            command.Parameters.AddWithValue("@email", addStudentModel.Email);
        //            command.Parameters.AddWithValue("@presentAddress", addStudentModel.PresentAddress);
        //            command.Parameters.AddWithValue("@permanentAddress", addStudentModel.PermanentAddress);
        //            command.Parameters.AddWithValue("@genderId", addStudentModel.GenderId);
        //            command.Parameters.AddWithValue("@nationality", addStudentModel.NationalityId);
        //            command.Parameters.AddWithValue("@departmentId", addStudentModel.DeptId);
        //            command.Parameters.AddWithValue("@sessionId", addStudentModel.SessionId);
        //            command.Parameters.AddWithValue("@yearTermId", addStudentModel.YearTermId);
        //            command.Parameters.AddWithValue("@salt", addStudentModel.Salt);
        //            command.Parameters.AddWithValue("@password", addStudentModel.Password);

        //            connection.Open();
        //            rowsInserted = command.ExecuteNonQuery();
        //            connection.Close();
        //            command.Parameters.Clear();
        //        }
        //    }
        //    return rowsInserted;
        //}        

    }
}