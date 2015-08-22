using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class AddStudentModel
    {
        public int ID { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int GenderId { get; set; }
        public int NationalityId { get; set; }
        public int DeptId { get; set; }
        public int YearTermId { get; set; }
        public int SessionId { get; set; }

        public string Salt { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }         

    }
}