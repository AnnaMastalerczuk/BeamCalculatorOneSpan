using BeamCalculatorOneSpanApp.Commands;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public bool CanGenerateCharts =>

            HasSelectedElement &&
            HasBeamLength;


        private bool _hasSelectedElement;

        public bool HasSelectedElement
        {
            get { return _hasSelectedElement; }
            set
            {
                if (_hasSelectedElement != value)
                {
                    _hasSelectedElement = value;
                    OnPropertyChanged(nameof(HasSelectedElement));
                    OnPropertyChanged(nameof(CanGenerateCharts));
                }
            }
        }

        private bool _hasBeamLength;

        public bool HasBeamLength
        {
            get { return _hasBeamLength; }
            set
            {
                if (_hasBeamLength != value)
                {
                    _hasBeamLength = value;
                    OnPropertyChanged(nameof(HasBeamLength));
                    OnPropertyChanged(nameof(CanGenerateCharts));
                }
            }
        }


        public ICommand GenerateChartsCommand { get; }

        public ElementViewModel(BeamDimensionStore beamDimensionStore, LoadPointListStore loadPointListStore, ElementStore elementStore)
        {
            BeamPickerComponentViewModel = new BeamPickerComponentViewModel(elementStore);
            DimensionComponentViewModel = new DimensionComponentViewModel(beamDimensionStore);
            LoadPointListComponentViewModel = new LoadPointListComponentViewModel(beamDimensionStore);
            LoadDistributedListComponentViewModel = new LoadDistributedListComponentViewModel(beamDimensionStore);
            ResultViewComponentViewModel = new ResultViewComponentViewModel(loadPointListStore, elementStore);

            GenerateChartsCommand = new GenerateChartsCommand(this, beamDimensionStore, loadPointListStore);

            BeamPickerComponentViewModel.PropertyChanged += OnBeamPickerComponentViewModelPropertyChanged;
            DimensionComponentViewModel.PropertyChanged += OnDimensionComponentViewModelPropertyChanged;

        }

        private void OnBeamPickerComponentViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(BeamPickerComponentViewModel.SelectedElement))
            {
                HasSelectedElement = BeamPickerComponentViewModel.SelectedElement != null;
            }
        }

        private void OnDimensionComponentViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(DimensionComponentViewModel.BeamLength))
            {
                HasBeamLength = DimensionComponentViewModel.BeamLength > 0;
            }
        }

    }
}
