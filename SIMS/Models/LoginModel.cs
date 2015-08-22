using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class LoginModel
    {        
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Password { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }

    }
}