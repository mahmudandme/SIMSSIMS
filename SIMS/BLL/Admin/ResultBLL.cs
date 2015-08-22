using System.Collections.Generic;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class ResultBLL
    {
        ResultDAL resultDal = new ResultDAL();

        public List<DepartmentModel> GetAllDepartmentId()
        {
            return resultDal.GetAllDepartmentId();
        }

        public List<DepartmentModel> GetAllDepartmentName(List<DepartmentModel> departmentModelsParameter)
        {
            return resultDal.GetAllDepartmentName(departmentModelsParameter);
        }

        public List<SessionMedel> GetAllSessionIdByDepetId(int deptId)
        {
            return resultDal.GetAllSessionIdByDepetId(deptId);
        }

        public List<SessionMedel> GetAllSessionBySessionId(List<SessionMedel> sessionMedelsParameter)
        {
            return resultDal.GetAllSessionBySessionId(sessionMedelsParameter);
        }

        public List<YearTermModel> GetAllYearTermIdBysessionId(int sessionId)
        {
            return resultDal.GetAllYearTermIdBysessionId(sessionId);
        }

        public List<YearTermModel> GetAllYearTermByYearTermId(List<YearTermModel> yearTermModelsParameter)
        {
            return resultDal.GetAllYearTermByYearTermId(yearTermModelsParameter);
        }

        public List<StudentModel> GetAllStudentIdByDeptIdSessionIdYearTermId(int deptId, int sessionId, int yearTermId)
        {
            return resultDal.GetAllStudentIdByDeptIdSessionIdYearTermId(deptId, sessionId, yearTermId);
        }

        public List<CourseModel> GetAllCourseByDeptIdYearTermId(int deptId, int yearTermId)
        {
            return resultDal.GetAllCourseByDeptIdYearTermId(deptId, yearTermId);
        }

        public List<GPAModel> GetAllGPA()
        {
            return GetAllGPA();
        }
    }
}