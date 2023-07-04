using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.BeamInfo
{
    public class LoadPoint : Load
    {
        public LoadPoint(int startPosition, double loadValue) : base(startPosition, loadValue)
        {

        }

        public LoadPoint()
        {

        }
    }
}
