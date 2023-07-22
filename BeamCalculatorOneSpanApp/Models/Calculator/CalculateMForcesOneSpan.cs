using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeamCalculatorOneSpanApp.Models.Calculator
{
    public class CalculateMForcesOneSpan
    {
        public int Length { get; set; }

        public List<Point> CalculateMForces(Dictionary<string, double> reactionsList, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Length = beamData.BeamLength;
            return CreateListOfPointsM(reactionsList, beamData, loadPoint, loadDistributed);
        }

        private List<Point> CreateListOfPointsM(Dictionary<string, double> reactionsList, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            List<Point> ListOfPointsM = new List<Point>();

            for (double i = 0; i <= Length; i += 10)
            {
                double value = -((CalculateV1MomentValue(i, reactionsList, beamData) + CalculateV2MomentValue(i, reactionsList, beamData)
                    - CalculatePMomentValue(i, loadPoint) - CalculateQMomentValue(i, loadDistributed, beamData)));
                Point point;
                if (i > 0)
                {
                    point = new Point(Math.Round(i / 1000, 2), Math.Round(value, 2));
                } else
                {
                    point = new Point(i, Math.Round(value, 2));
                }
                
                ListOfPointsM.Add(point);
            }

            return ListOfPointsM;
        }

         private double CalculateV1MomentValue(double position, Dictionary<string, double> reactionsList, BeamDimension beamData)
        {
            double value = 0;

            if (position > beamData.CantileverLeft)
            {
                bool isV1 = reactionsList.TryGetValue("V1", out double V1value);
                value = V1value * (position - beamData.CantileverLeft) / 1000;
            }
            return value;
        }

        private double CalculateV2MomentValue(double position, Dictionary<string, double> reactionsList, BeamDimension beamData)
        {
            double value = 0;

            if (position > beamData.CantileverLeft + beamData.SpanOne)
            {
                bool isV2 = reactionsList.TryGetValue("V2", out double V2value);
                value = V2value * (position - beamData.CantileverLeft - beamData.SpanOne) / 1000;
            }
            return value;
        }

        private double CalculatePMomentValue(double position, List<LoadPoint> loadPoint)
        {
            double value = 0;

            if (loadPoint.Count > 0)
            {
                foreach (LoadPoint load in loadPoint)
                {
                    if (position > load.StartPosition)
                    {
                        value += load.LoadValue * (position - load.StartPosition) / 1000;
                    }
                }
            }
            return value;
        }

        private double CalculateQMomentValue(double position, List<LoadDistributed> loadDistributed, BeamDimension beamData)
        {
            double value = 0;

            if (loadDistributed.Count > 0)
            {
                foreach (LoadDistributed load in loadDistributed)
                {
                    if (position > load.StartPosition && position <= load.EndPosition)
                    {
                        value += load.LoadValue * (position - load.StartPosition) * ((position - load.StartPosition) / 2) / 1000000;
                    }
                    else if (position > load.EndPosition)
                    {
                        value += load.LoadValue * (load.EndPosition - load.StartPosition) * (position - load.EndPosition + (load.EndPosition - load.StartPosition) / 2) / 1000000;
                    }
                }
            }

            return value;
        }
    }
}

