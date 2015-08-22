using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class StudentModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string DepartmentName { get; set; }
        public string Session { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }    
    }
}