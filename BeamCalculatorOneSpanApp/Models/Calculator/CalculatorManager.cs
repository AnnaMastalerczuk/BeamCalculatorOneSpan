using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Models.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models.Calculator
{
    public class CalculatorManager
    {
        private CalculateForcesOneSpan _calculateForcesOneSpan;
        private CalculateMForcesOneSpan _calculateMForcesOneSpan;
        private CalculateTForcesOneSpan _calculateTForcesOneSpan;

        public CalculatorManager()
        {
            //_calculateForcesOneSpan = new CalculateForcesOneSpan();
            _calculateMForcesOneSpan = new CalculateMForcesOneSpan();
            _calculateTForcesOneSpan = new CalculateTForcesOneSpan();

        }

        public List<Point> CalculateTForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed, Dictionary<string, double> reactionsList)
        {
            List<Point> listOfPointsT = new List<Point>();

            return listOfPointsT = _calculateTForcesOneSpan.CalculateTForces(reactionsList, beamData, loadPoint, loadDistributed);

        }

        public List<Point> CalculateMForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed, Dictionary<string, double> reactionsList)
        {
            List<Point> listOfPointsM = new List<Point>();

            return listOfPointsM = _calculateMForcesOneSpan.CalculateMForces(reactionsList, beamData, loadPoint, loadDistributed);

        }


    }
}
