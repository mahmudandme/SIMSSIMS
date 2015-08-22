using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models
{
    public class GPAModel
    {
        public int ID { get; set; }
        public string Range { get; set; }
        public decimal GPA { get; set; }
        public string GPAType { get; set; }

    }
}