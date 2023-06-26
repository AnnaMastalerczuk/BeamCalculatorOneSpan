using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class ElementViewModel : ViewModelBase
    {
        public BeamPickerComponentViewModel BeamPickerComponentViewModel { get; }
        public DimensionComponentViewModel DimensionComponentViewModel { get; }

        public ElementViewModel()
        {
            BeamPickerComponentViewModel = new BeamPickerComponentViewModel();
            DimensionComponentViewModel = new DimensionComponentViewModel();
        }
    }
}
