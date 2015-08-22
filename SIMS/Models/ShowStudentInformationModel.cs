using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class ShowStudentInformationModel
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string DepartmentName { get; set; }
        public string Session { get; set; }
        public string YearTerm { get; set; }
    }
}