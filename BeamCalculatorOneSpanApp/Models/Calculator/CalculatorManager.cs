using BeamCalculatorOneSpanApp.Models.BeamInfo;
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

        public CalculatorManager()
        {
            _calculateForcesOneSpan = new CalculateForcesOneSpan();

        }

        public List<Point> CalculateTForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed, Dictionary<string, double> reactionsList)
        {
            List<Point> listOfPointsT = new List<Point>();

            return listOfPointsT = _calculateForcesOneSpan.CalculateTForces(reactionsList, beamData, loadPoint, loadDistributed);

        }

        public List<Point> CalculateMForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed, Dictionary<string, double> reactionsList)
        {
            List<Point> listOfPointsM = new List<Point>();

            return listOfPointsM = _calculateForcesOneSpan.CalculateMForces(reactionsList, beamData, loadPoint, loadDistributed);

        }


    }
}
