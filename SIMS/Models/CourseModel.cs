using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public decimal Credit { get; set; }
    }
}