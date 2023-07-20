using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Stores;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class LoadDistributedListComponentViewModel : ViewModelBase
    {
        private readonly BeamDimensionStore _beamDimensionStore;
        public string BeamLength => (_beamDimensionStore?.BeamDimension.BeamLength).ToString() ?? "";

        private ObservableCollection<LoadDistributed> _listLoadDistributed;
        public ObservableCollection<LoadDistributed> ListLoadDistributed
        {
            get
            {
                return _listLoadDistributed;
            }
            set
            {
                _listLoadDistributed = value;
                OnPropertyChanged(nameof(ListLoadDistributed));

            }
        }

        private DelegateCommand<LoadDistributed> _deleteLoadDistributedCommand;
       

        public DelegateCommand<LoadDistributed> DeleteLoadDistributedCommand =>
           _deleteLoadDistributedCommand ?? (_deleteLoadDistributedCommand = new DelegateCommand<LoadDistributed>(ExecuteDeleteLoadDistributedCommand));
        void ExecuteDeleteLoadDistributedCommand(LoadDistributed parameter)
        {
            if (ListLoadDistributed.Count != 0)
            {
                ListLoadDistributed.Remove(parameter);
            }
            
        }

        public LoadDistributedListComponentViewModel(BeamDimensionStore beamDimensionStore)
        {
            ListLoadDistributed = new ObservableCollection<LoadDistributed>();
            _beamDimensionStore = beamDimensionStore;
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
