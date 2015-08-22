using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class AdminModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdminId { get; set; }
        public string Salt { get; set; }
        public string  Password { get; set; }
        public string OnlyPassword { get; set; }
        public int Type { get; set; }

    }
}