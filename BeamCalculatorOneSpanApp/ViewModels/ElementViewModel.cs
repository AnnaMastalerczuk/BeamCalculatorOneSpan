using BeamCalculatorOneSpanApp.Commands;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Media;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class ElementViewModel : ViewModelBase
    {
        public BeamPickerComponentViewModel BeamPickerComponentViewModel { get; }
        public DimensionComponentViewModel DimensionComponentViewModel { get; }
        public LoadPointListComponentViewModel LoadPointListComponentViewModel { get; }
        public ResultViewComponentViewModel ResultViewComponentViewModel { get; }

        public ICommand GenerateChartsCommand { get; }


        public void GenerateChartsButton()
        {
            //ActivateItem(new ResultViewComponentViewModel());
            

        }

        public ElementViewModel(BeamDimensionStore _beamDimensionStore, TestStore testStore)
        {
            BeamPickerComponentViewModel = new BeamPickerComponentViewModel();
            DimensionComponentViewModel = new DimensionComponentViewModel(_beamDimensionStore);
            LoadPointListComponentViewModel = new LoadPointListComponentViewModel(_beamDimensionStore);
            ResultViewComponentViewModel = new ResultViewComponentViewModel(testStore);

            GenerateChartsCommand = new GenerateChartsCommand(this, testStore);
           

        }

    }
}
