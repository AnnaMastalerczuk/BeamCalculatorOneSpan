using BeamCalculatorOneSpanApp.Models.BeamInfo;
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
            ListLoadDistributed.Remove(parameter);

        }

        public LoadDistributedListComponentViewModel()
        {
            ListLoadDistributed = new ObservableCollection<LoadDistributed>()
            {

            };
        }
    }
}
