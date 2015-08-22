using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class AddSessionBLL
    {
        AddSessionDAL addSessionDal = new AddSessionDAL();
        public bool IsSessionExist(SessionMedel sessionMedel)
        {
            return addSessionDal.IsSessionExist(sessionMedel);
        }

        public int SaveSession(SessionMedel sessionMedel)
        {
            return addSessionDal.SaveSession(sessionMedel);
        }
        public List<SessionMedel> GetAllSession()
        {
            return addSessionDal.GetAllSession();
        }
    }
}