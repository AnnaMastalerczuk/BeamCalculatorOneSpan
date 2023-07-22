using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Stores;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class LoadPointListComponentViewModel : ViewModelBase
    {
        private readonly BeamDimensionStore _beamDimensionStore;
        public string BeamLength => (_beamDimensionStore.BeamDimension?.BeamLength).ToString() ?? "";

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
            _deleteLoadPointCommand ?? (_deleteLoadPointCommand = new DelegateCommand<LoadPoint>(ExecuteDeleteLoadPointCommand, CanExecuteDeleteLoadPointCommand));
        void ExecuteDeleteLoadPointCommand(LoadPoint parameter)
        {
            //if (ListLoadPoint.Count > 0)
            //{
            //    ListLoadPoint.Remove(parameter);
            //}

            ListLoadPoint.Remove(parameter);

        }
        bool CanExecuteDeleteLoadPointCommand(LoadPoint parameter)
        {
            //return parameter != null && ListLoadPoint.Contains(parameter);
            return parameter != null;
        }

        private DelegateCommand _addNewLoadPointCommand;

        public DelegateCommand AddNewLoadPointCommand =>
            _addNewLoadPointCommand ?? (_addNewLoadPointCommand = new DelegateCommand(ExecuteAddNewLoadPointCommand));

        void ExecuteAddNewLoadPointCommand()
        {
            ListLoadPoint.Add(new LoadPoint());
        }


        //ctor
        public LoadPointListComponentViewModel(BeamDimensionStore beamDimensionStore)
        {
            ListLoadPoint = new ObservableCollection<LoadPoint>();

            _beamDimensionStore = beamDimensionStore;

            _beamDimensionStore.BeamDimensionChanged += BeamDimensionStore_BeamDimensionStoreChanged;

            _deleteLoadPointCommand = new DelegateCommand<LoadPoint>(ExecuteDeleteLoadPointCommand, CanExecuteDeleteLoadPointCommand);

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
