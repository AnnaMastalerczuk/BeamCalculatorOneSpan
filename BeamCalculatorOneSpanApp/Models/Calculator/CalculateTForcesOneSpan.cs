using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Models.Calculator
{
    public class CalculateTForcesOneSpan
    {
        public int Length { get; set; }
        public List<Point> CalculateTForces(Dictionary<string, double> reactionsList, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Length = beamData.BeamLength;
            return CreateListOfPointsT(reactionsList, beamData, loadPoint, loadDistributed);
        }

        private List<Point> CreateListOfPointsT(Dictionary<string, double> reactionsList, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            List<Point> ListOfPointsT = new List<Point>();

            for (double i = 0; i <= Length; i += 10)
            {
                double value = CalculateV1Value(i, reactionsList, beamData) + CalculateV2Value(i, reactionsList, beamData)
                    - CalculateQValue(i, loadDistributed) - CalculatePValue(i, loadPoint);
                Point point;
                if (i > 0)
                {
                    point = new Point(Math.Round(i / 1000, 2), Math.Round(value, 2));
                }
                else
                {
                    point = new Point(i, Math.Round(value, 2));
                }
                ListOfPointsT.Add(point);
            }

            return ListOfPointsT;
        }

        private double CalculateV1Value(double position, Dictionary<string, double> reactionsList, BeamDimension beamData)
        {
            double value = 0;
            if (position >= beamData.CantileverLeft)
            {
                bool isV1 = reactionsList.TryGetValue("V1", out value);
            }

            return value;
        }

        private double CalculateV2Value(double position, Dictionary<string, double> reactionsList, BeamDimension beamData)
        {
            double value = 0;

            if (position >= beamData.CantileverLeft + beamData.SpanOne)
            {
                bool isV2 = reactionsList.TryGetValue("V2", out value);
            }
            return value;
        }

        private double CalculatePValue(double position, List<LoadPoint> loadPoint)
        {
            double value = 0;

            if (loadPoint.Count > 0)
            {
                foreach (LoadPoint load in loadPoint)
                {
                    if (position >= load.StartPosition)
                    {
                        value += load.LoadValue;
                    }
                }
            }

            return value;
        }

        private double CalculateQValue(double position, List<LoadDistributed> loadDistributed)
        {
            double value = 0;

            if (loadDistributed.Count > 0)
            {
                foreach (LoadDistributed load in loadDistributed)
                {
                    if (position >= load.StartPosition && position <= load.EndPosition)
                    {
                        value += load.LoadValue * (position - load.StartPosition) / 1000;
                    }
                    else if (position > load.EndPosition)
                    {
                        value += load.LoadValue * (load.EndPosition - load.StartPosition) / 1000;
                    }
                }

            }

            return value;
        }    
    }
}
