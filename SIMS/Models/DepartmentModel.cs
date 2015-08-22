using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class DepartmentModel
    {
        public int DeptID { get; set; }
        public string DepartmentName { get; set; }
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }

    }
}