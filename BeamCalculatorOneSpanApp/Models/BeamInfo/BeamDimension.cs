using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.BeamInfo
{
    public class BeamDimension
    {
        public BeamDimension()
        {
            
        }

        public int CantileverLeft { get; set; }
        public int CantileverRight { get; set; }
        public int SpanOne { get; set; }
        public int BeamLength 
        {
            get
            {
                return (CantileverRight + CantileverLeft + SpanOne);
            }
 
        }
    }
}
