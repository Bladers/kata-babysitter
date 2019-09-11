using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitterKata
{
    public class Family
    {
        public string FamilyName { get; set; }
        public string FamilyAbbreviation { get; set; }
        public List<PayRate> WorkHours { get; set; }
    }
}
