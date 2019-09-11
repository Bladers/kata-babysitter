using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitterKata
{
    public class Sitter
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Family { get; set; }
        public double TotalPay { get; set; }
        public double TotalHours { get; set; }
        public bool ErrorFlag { get; set; }
    }
}
