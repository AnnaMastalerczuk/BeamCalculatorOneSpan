using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.Calculator
{
    public class TestCalculator
    {

        public string Test(Element element)
        {
            if (element == null) return "ania";

            return element.Name;
        }
    }
}
