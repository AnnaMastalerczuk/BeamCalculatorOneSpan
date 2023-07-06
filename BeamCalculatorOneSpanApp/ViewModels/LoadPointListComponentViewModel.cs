using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Stores;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class LoadPointListComponentViewModel : ViewModelBase
    {
        private readonly BeamDimensionStore _beamDimensionStore;

        //public string BeamLength => (_beamDimensionStore.BeamDimension?.SpanOne.ToString() ?? "100");
        public string BeamLength => (_beamDimensionStore.BeamDimension?.BeamLength).ToString() ?? "50";


        private ObservableCollection<LoadPoint> _listLoadPoint;
        public ObservableCollection<LoadPoint> ListLoadPoint
        {
            get
            {
                return _listLoadPoint;
            }
            set
            {
                _listLoadPoint = value;
                OnPropertyChanged(nameof(ListLoadPoint));
            }
        }


        //Load list command

        private DelegateCommand<LoadPoint> _deleteLoadPointCommand;
        public DelegateCommand<LoadPoint> DeleteLoadPointCommand =>
            _deleteLoadPointCommand ?? (_deleteLoadPointCommand = new DelegateCommand<LoadPoint>(ExecuteDeleteLoadPointCommand));
        void ExecuteDeleteLoadPointCommand(LoadPoint parameter)
        {
            ListLoadPoint.Remove(parameter);

        }        

        //ctor
        public LoadPointListComponentViewModel(BeamDimensionStore beamDimensionStore)
        {
            ListLoadPoint = new ObservableCollection<LoadPoint>()
            {

            };
            this._beamDimensionStore = beamDimensionStore;

            _beamDimensionStore.BeamDimensionChanged += BeamDimensionStore_BeamDimensionStoreChanged;
        }

        //beamstore changed

        protected override void Dispose()
        {
            _beamDimensionStore.BeamDimensionChanged -= BeamDimensionStore_BeamDimensionStoreChanged;
            base.Dispose();
        }
        private void BeamDimensionStore_BeamDimensionStoreChanged()
        {
            OnPropertyChanged(nameof(BeamLength));
        }

    }
}
