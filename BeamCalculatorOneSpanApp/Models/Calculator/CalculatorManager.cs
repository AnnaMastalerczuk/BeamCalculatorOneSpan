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
        private CalculateReactionsOneSpan _calculateReactionsOneSpan;
        private CalculateForcesOneSpan _calculateForcesOneSpan;

        public CalculatorManager()
        {
            _calculateReactionsOneSpan = new CalculateReactionsOneSpan();
            _calculateForcesOneSpan = new CalculateForcesOneSpan();

        }

        public List<Point> CalculateTForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Dictionary<string, double> reactionsList = new Dictionary<string, double>();
            List<Point> listOfPointsT = new List<Point>();

            //reactionsList = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
            reactionsList = CalculateReactions(beamData, loadPoint, loadDistributed);
            return listOfPointsT = _calculateForcesOneSpan.CalculateTForces(reactionsList, beamData, loadPoint, loadDistributed);

        }

        public List<Point> CalculateMForces(Element element, BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Dictionary<string, double> reactionsList = new Dictionary<string, double>();
            List<Point> listOfPointsM = new List<Point>();

            //reactionsList = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
            reactionsList = CalculateReactions(beamData, loadPoint, loadDistributed);
            return listOfPointsM = _calculateForcesOneSpan.CalculateMForces(reactionsList, beamData, loadPoint, loadDistributed);

        }


        private Dictionary<string, double> CalculateReactions(BeamDimension beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            Dictionary<string, double> reactionsList = new Dictionary<string, double>();
            reactionsList = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
            return reactionsList;
        }

    }
}
