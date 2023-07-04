using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Stores
{
    public class BeamDimensionStore
    {
        private BeamDimension _beamDimension;
        public BeamDimension BeamDimension
        {
            get { return _beamDimension; }
            set
            {
                _beamDimension = value;
                BeamDimensionChanged?.Invoke();
            }
        }

        public event Action BeamDimensionChanged;


    }
}
