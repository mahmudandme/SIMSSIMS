using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMS.DAL.Admin;
using SIMS.Models;

namespace SIMS.BLL.Admin
{
    public class AddNationalityBLL
    {
        AddNationalityDAL addNationalityDal = new AddNationalityDAL();
        public bool IsNationalityExist(NationalityModel nationalityModel)
        {
            return addNationalityDal.IsNationalityExist(nationalityModel);
        }

        public int SaveNationality(NationalityModel nationalityModel)
        {
            return addNationalityDal.SaveNationality(nationalityModel);
        }


        public List<NationalityModel> GetAllNationality()
        {
            return addNationalityDal.GetAllNationality();
        }

    }
}