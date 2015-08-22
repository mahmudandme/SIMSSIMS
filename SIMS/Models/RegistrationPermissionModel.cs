using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class RegistrationPermissionModel
    {
        public string studentId { get; set; }
        public int DeptId { get; set; }
        public int SessionId { get; set; }
        public int YearTermId { get; set; }
    }
}