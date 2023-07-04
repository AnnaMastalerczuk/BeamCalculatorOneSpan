//using BeamCalculator.Models.BeamInfo;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeamCalculator.Models.Calculator
//{
//    public class CalculatorManager
//    {
//        private CalculateReactionsOneSpan _calculateReactionsOneSpan;
//        private CalculateForcesOneSpan _calculateForcesOneSpan;

//        public CalculatorManager()
//        {
//            _calculateReactionsOneSpan = new CalculateReactionsOneSpan();
//            _calculateForcesOneSpan = new CalculateForcesOneSpan();

//        }

//        public void Calculate(Element element, BeamData beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
//        {
//            Dictionary<string, double> reactionsList = new Dictionary<string, double>();

//            reactionsList = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
//            _calculateForcesOneSpan.CalculateForces(reactionsList, beamData, loadPoint, loadDistributed);

//        }

//    }
//}
