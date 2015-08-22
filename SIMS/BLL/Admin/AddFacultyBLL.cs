using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class AddFacultyBLL
    {
        AddFacultyDAL addFacultyDal = new AddFacultyDAL();

        public bool IsDepartNameExist(AddFacultyModel addFacultyModel)
        {
            return addFacultyDal.IsFacultyNameExist(addFacultyModel);
        }

        public int SaveDepartmentName(AddFacultyModel addFacultyModel)
        {
            return addFacultyDal.SaveDepartmentName(addFacultyModel);
        }

        public List<AddFacultyModel> GetAllFaculty()
        {
            return addFacultyDal.GetAllFaculty();
        }

        public int DeleteFaculty(AddFacultyModel addFacultyModel)
        {
            return addFacultyDal.DeleteFaculty(addFacultyModel);
        }

    }
}