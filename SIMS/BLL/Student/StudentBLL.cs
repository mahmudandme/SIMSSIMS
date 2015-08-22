using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Student;
using SIMS.Models;

namespace SIMS.BLL.Student
{
    public class StudentBLL
    {
        StudentDAL studentDal = new StudentDAL();
        public StudentModel GetStudentInfirmation(string studentId)
        {
            return studentDal.GetStudentInformation(studentId);
        }
        public int UpdatePhoneNumber(string phoneNumber, string studentId, string email)
        {
            return studentDal.UpdatePhoneNumber(phoneNumber, studentId, email);
        }
        public int UpdatePresentAddress(string address, string studentId, string email)
        {
            return studentDal.UpdatePresentAddress(address, studentId, email);
        }

        public List<CourseModel> GetAllCoursesByDeptIdAndYearTermId(int deptId, int yearTermId)
        {
            return studentDal.GetAllCoursesByDeptIdAndYearTermId(deptId, yearTermId);
        }

        public AddStudentModel GetDeptIdAndSessionIdByStudentIdAndEmail(string studentId, string email)
        {
            return studentDal.GetDeptIdAndSessionIdByStudentIdAndEmail(studentId, email);
        }

        public string GetYearTermByYearTermId(int yearTermId)
        {
            return studentDal.GetYearTermByYearTermId(yearTermId);
        }

        public bool IsSemisterRegisteredForStudentId(RegistrationPermissionModel registrationPermissionModel)
        {
            return studentDal.IsSemisterRegisteredForStudentId(registrationPermissionModel);
        }

        public int SaveSemisterRegistrationForStudent(RegistrationPermissionModel registrationPermissionModel)
        {
            return studentDal.SaveSemisterRegistrationForStudent(registrationPermissionModel);
        }

    }
}