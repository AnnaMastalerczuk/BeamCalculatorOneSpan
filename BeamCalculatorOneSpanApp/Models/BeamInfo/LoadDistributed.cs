using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.BeamInfo
{
    public class LoadDistributed : Load
    {
        public int EndPosition { get; set; }

        public LoadDistributed(int startPosition, int endPosition, double loadValue) : base(startPosition, loadValue)
        {
            this.EndPosition = endPosition;

        }

        public LoadDistributed()
        {

        }
    }
}
