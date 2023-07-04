using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models.Calculator
{
    public class Point
    {
        public double X { get; set; }
        public double Value { get; set; }

        public Point(double x, double value)
        {
            this.X = x;
            this.Value = value;

        }
    }
}
