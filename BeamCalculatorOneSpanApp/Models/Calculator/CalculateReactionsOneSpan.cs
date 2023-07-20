using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BeamCalculator.Models.Calculator
{
    public class CalculateReactionsOneSpan
    {
        public Dictionary<string, double> CalculateReactions(BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Dictionary<string, double> reactions = new Dictionary<string, double>();

            double loadDistributedSumMoment = 0;
            double loadDistributedSum = 0;
            double loadPointSumMoment = 0;
            double loadPointSum = 0;

            if (loadDistributed.Count > 0)
            {
                loadDistributedSumMoment = LoadDistributedSumMoment(beamData, loadDistributed);
                loadDistributedSum = LoadDistributedSum(beamData, loadDistributed);
            }

            if (loadPoint.Count > 0)
            {
                loadPointSumMoment = LoadPointSumMoment(beamData, loadPoint);
                loadPointSum = LoadPointSum(beamData, loadPoint);
            }

            double V2 = calculateV2(loadDistributedSumMoment, loadPointSumMoment, beamData);
            double V1 = calculateV1(V2, loadDistributedSum, loadPointSum);

            reactions.Add("V1", V1);
            reactions.Add("V2", V2);

            return reactions;

        }

        private double calculateV2(double loadDistributedSumMoment, double loadPointSumMoment, BeamDimension beamData)
        {
            double V2 = 0;
            int number = 1; 
            double spanLength = number / 1000;
            V2 = ((loadDistributedSumMoment + loadPointSumMoment) / beamData.SpanOne) * 1000;

            return V2;
        }

        private double calculateV1(double V2, double loadDistributedSum, double loadPointSum)
        {
            double V1 = 0;

            V1 = +loadDistributedSum + loadPointSum - V2;

            return V1;
        }

        private double LoadDistributedSumMoment(BeamDimension beamData, List<LoadDistributed> loadDistributed)
        {
            double sum = 0;
            int cantileverLeft = beamData.CantileverLeft;

            for (int i = 0; i < loadDistributed.Count; i++)
            {
                double singleSum = 0;
                int loadLength = loadDistributed[i].EndPosition - loadDistributed[i].StartPosition;
                double load = LoadDistributedValue(loadDistributed[i].LoadValue, loadDistributed[i].StartPosition, loadDistributed[i].EndPosition);
                singleSum = (load * (loadDistributed[i].StartPosition - cantileverLeft + (loadLength / 2)) / 1000);
                sum += singleSum;
            }
            return sum;
        }

        private double LoadDistributedSum(BeamDimension beamData, List<LoadDistributed> loadDistributed)
        {
            double sum = 0;

            for (int i = 0; i < loadDistributed.Count; i++)
            {
                double singleSum = 0;
                double load = LoadDistributedValue(loadDistributed[i].LoadValue, loadDistributed[i].StartPosition, loadDistributed[i].EndPosition);
                singleSum = load;
                sum += singleSum;
            }

            return sum;
        }

        private double LoadDistributedValue(double load, int startPosition, int endPosition)
        {
            double loadValue = 0;
            int loadLength = endPosition - startPosition;

            loadValue = load * loadLength / 1000;

            return loadValue;
        }

        private double LoadPointSumMoment(BeamDimension beamData, List<LoadPoint> loadPoint)
        {
            double sum = 0;
            int cantileverLeft = beamData.CantileverLeft;

            for (int i = 0; i < loadPoint.Count; i++)
            {
                double singleSum = 0;
                singleSum = (loadPoint[i].LoadValue * (loadPoint[i].StartPosition - cantileverLeft)) / 1000;
                sum += singleSum;
            }
            return sum;
        }

        private double LoadPointSum(BeamDimension beamData, List<LoadPoint> loadPoint)
        {
            double sum = 0;

            for (int i = 0; i < loadPoint.Count; i++)
            {
                double singleSum = 0;
                singleSum = (loadPoint[i].LoadValue);
                sum += singleSum;
            }
            return sum;
        }
    }
}
