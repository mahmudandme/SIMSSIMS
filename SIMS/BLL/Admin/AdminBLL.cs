using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class AdminBLL
    {
        AdminDAL adminDal = new AdminDAL();

        public bool IsAdminExist(AdminModel adminModel)
        {
            return adminDal.IsAdminExist(adminModel);
        }
        public int SaveAdminInformation(AdminModel adminModel)
        {
            return adminDal.SaveAdminInformation(adminModel);
        }

        public List<AdminModel> GetAdminInformationByLastIdentity()
        {
            return adminDal.GetAdminInformationByLastIdentity();
        }
        public List<AdminModel> GetAllAdmin()
        {
            return adminDal.GetAllAdmin();
        }
        public LoginModel GetLoginInformation(string id1, string email1)
        {
            return adminDal.GetLoginInformation(id1, email1);
        }

        public bool IsRegistrationPermissionExist(RegistrationPermissionModel registrationPermissionModel)
        {
            return adminDal.IsRegistrationPermissionExist(registrationPermissionModel);
        }
        public int SaveRegistrationPermission(RegistrationPermissionModel registrationPermissionModel)
        {
            return adminDal.SaveRegistrationPermission(registrationPermissionModel);
        }

        public int GetMaxValueOfYearTermIdFromRegPermission(int deptId, int sessionId)
        {
            return adminDal.GetMaxValueOfYearTermIdFromRegPermission(deptId,sessionId);
        }

        

         
    }
}