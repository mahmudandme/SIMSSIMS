using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class TeacherModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public int DeptId { get; set; }
        public string JoiningDate { get; set; }


    }
}