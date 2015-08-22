using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class AddDepartmentBLL
    {
        AddDepartmentDAL addDepartmentDal = new AddDepartmentDAL();


        public List<AddFacultyModel> GetAllFacultyName()
        {
            return addDepartmentDal.GetAllFacultyName();
        }

        public bool IsDepartNameExist(DepartmentModel departmentModel)
        {
            return addDepartmentDal.IsDepartNameExist(departmentModel);
        }

        public int SaveDepartmentName(DepartmentModel departmentModel)
        {
            return addDepartmentDal.SaveDepartmentName(departmentModel);
        }

        public List<ShowAllDepartmentInformationModel> ShowAllDepartment()
        {
            return addDepartmentDal.ShowAllDepartmentInfo();
        }
    }
}