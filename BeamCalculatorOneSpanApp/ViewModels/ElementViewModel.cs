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
        public LoadDistributedListComponentViewModel LoadDistributedListComponentViewModel { get; }
        public ResultViewComponentViewModel ResultViewComponentViewModel { get; set; }

        private string _text;

        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }


        public ICommand GenerateChartsCommand { get; }

        public ElementViewModel(BeamDimensionStore _beamDimensionStore, LoadPointListStore _loadPointListStore, ElementStore _elementStore)
        {
            BeamPickerComponentViewModel = new BeamPickerComponentViewModel(_elementStore);
            DimensionComponentViewModel = new DimensionComponentViewModel(_beamDimensionStore);
            LoadPointListComponentViewModel = new LoadPointListComponentViewModel(_beamDimensionStore);
            LoadDistributedListComponentViewModel = new LoadDistributedListComponentViewModel(_beamDimensionStore);
            ResultViewComponentViewModel = new ResultViewComponentViewModel(_loadPointListStore, _elementStore);

            GenerateChartsCommand = new GenerateChartsCommand(this, _beamDimensionStore, _loadPointListStore);

        }

    }
}
