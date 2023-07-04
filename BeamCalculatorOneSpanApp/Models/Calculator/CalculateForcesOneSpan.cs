//using BeamCalculator.Models.BeamInfo;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Media.Animation;

//namespace BeamCalculator.Models.Calculator
//{
//    public class CalculateForcesOneSpan
//    {
//        public int Length { get; set; }
//        public List<Point> ListOfPointsT { get; }
//        public List<Point> ListOfPointsM { get; }


//        //private int Length { get; set; }

//        public CalculateForcesOneSpan()
//        {
//            ListOfPointsT = new List<Point>();
//            ListOfPointsM = new List<Point>();
//        }

//        public void CalculateForces(Dictionary<string, double> reactionsList, BeamData beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
//        {
//            Length = beamData.CantileverRight + beamData.CantileverLeft + beamData.SpanOne;
//            CreateListOfPointsT(reactionsList, beamData, loadPoint, loadDistributed);
//            CreateListOfPointsM(reactionsList, beamData, loadPoint, loadDistributed);
//        }

//        private void CreateListOfPointsT(Dictionary<string, double> reactionsList, BeamData beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
//        {
//            for (double i = 0; i <= Length; i += 10)
//            {
//                double value = CalculateV1Value(i, reactionsList, beamData) + CalculateV2Value(i, reactionsList, beamData) 
//                    - CalculateQValue(i, loadDistributed) - CalculatePValue(i, loadPoint);
//                Point point = new Point(i, value);
//                ListOfPointsT.Add(point);
//            }
//        }

//        private void CreateListOfPointsM(Dictionary<string, double> reactionsList, BeamData beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
//        {
//            for (double i = 0; i <= Length; i += 10)
//            {
//                double value = -(CalculateV1MomentValue(i, reactionsList, beamData) + CalculateV2MomentValue(i, reactionsList, beamData) 
//                    - CalculatePMomentValue(i, loadPoint) - CalculateQMomentValue(i, loadDistributed, beamData));
//                Point point = new Point(i, value);
//                ListOfPointsM.Add(point);
//            }
//        }
//        private double CalculateV1Value(double position, Dictionary<string, double> reactionsList, BeamData beamData)
//        {
//            double value = 0;
//            if (position >= beamData.CantileverLeft)
//            {
//                bool isV1 = reactionsList.TryGetValue("V1", out value);
//            }

//            return value;
//        }

//        private double CalculateV2Value(double position, Dictionary<string, double> reactionsList, BeamData beamData)
//        {
//            double value = 0;

//            if (position >= beamData.CantileverLeft + beamData.SpanOne)
//            {
//                bool isV2 = reactionsList.TryGetValue("V2", out value);
//            }
//            return value;
//        }

//        private double CalculatePValue(double position, List<LoadPoint> loadPoint)
//        {
//            double value = 0;

//            if (loadPoint.Count > 0) 
//            { 
//                foreach (LoadPoint load in loadPoint)
//                {
//                    if (position >= load.StartPosition)
//                    {
//                        value = load.LoadValue;
//                    }
//                }
//            }

//            return value;
//        }

//        private double CalculateQValue(double position, List<LoadDistributed> loadDistributed)
//        {
//            double value = 0;

//            if (loadDistributed.Count > 0)
//            {
//                foreach (LoadDistributed load in loadDistributed)
//                {
//                    if (position >= load.StartPosition && position <= load.EndPosition)
//                    {
//                        value = load.LoadValue * (position - load.StartPosition) / 1000;
//                    }
//                    else if (position > load.EndPosition)
//                    {
//                        value = load.LoadValue * (load.EndPosition - load.StartPosition) / 1000;
//                    }
//                }

//            }

//            return value;
//        }

//        private double CalculateV1MomentValue(double position, Dictionary<string, double> reactionsList, BeamData beamData)
//        {
//            double value = 0;

//            if (position > beamData.CantileverLeft)
//            {
               
//                bool isV1 = reactionsList.TryGetValue("V1", out double V1value);
//                value = V1value * (position - beamData.CantileverLeft) / 1000;
//            }
//            return value;
//        }

//        private double CalculateV2MomentValue(double position, Dictionary<string, double> reactionsList, BeamData beamData)
//        {
//            double value = 0;

//            if (position > beamData.CantileverLeft + beamData.SpanOne)
//            {
//                bool isV2 = reactionsList.TryGetValue("V2", out double V2value);
//                value = V2value * (position - beamData.CantileverLeft - beamData.SpanOne) / 1000;
//            }
//            return value;
//        }

//        private double CalculatePMomentValue(double position, List<LoadPoint> loadPoint)
//        {
//            double value = 0;

//            if (loadPoint.Count > 0)
//            {
//                foreach (LoadPoint load in loadPoint)
//                {
//                    if (position > load.StartPosition)
//                    {
//                        value = load.LoadValue * (position - load.StartPosition) / 1000;
//                    }
//                }
//            }
//            return value;
//        }

//        private double CalculateQMomentValue(double position, List<LoadDistributed> loadDistributed, BeamData beamData)
//        {
//            double value = 0;

//            if(loadDistributed.Count > 0)
//            {
//                foreach (LoadDistributed load in loadDistributed)
//                {
//                    if (position >= load.StartPosition && position <= load.EndPosition)
//                    {
//                        value = load.LoadValue * (position - load.StartPosition) * ((position - load.StartPosition) / 2) / 1000000;
//                    }
//                    else if (position > load.EndPosition)
//                    {
//                        value = load.LoadValue * (load.EndPosition - load.StartPosition) * (position - beamData.CantileverLeft - (load.EndPosition - load.StartPosition) / 2) / 1000000;
//                    }
//                }
//            }

//            return value;
//        }
//    }
//}
