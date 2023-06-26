using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.BeamInfo
{
   public class Element
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double MaxM { get; set; }
        public double MaxT { get; set; }
    }
}
