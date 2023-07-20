using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class DimensionComponentViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;
        private readonly BeamDimensionStore _beamDimensionStore;

        private BeamDimension beamDimension = new BeamDimension();


        //Dimensions
        private string _cantileverLeft = "0";
        public string CantileverLeft
        {
            get
            {
                return _cantileverLeft;
            }
            set
            {
                _cantileverLeft = value;

                _errorsViewModel.ClearErrors(nameof(CantileverLeft));
                if (CantileverLeft.Contains('.') || CantileverLeft.Contains(',') || CantileverLeft.Any(Char.IsLetter))
                {
                    _errorsViewModel.AddError(nameof(CantileverLeft), "Niepoprawny format. Podaj wymiary w mm");
                }

                OnPropertyChanged(nameof(CantileverLeft));
                OnPropertyChanged(nameof(BeamLength));

                beamDimension.CantileverLeft = int.Parse(_cantileverLeft);
                _beamDimensionStore.BeamDimension = beamDimension;
            }
        }


        private string _cantileverRight = "0";
        public string CantileverRight
        {
            get
            {
                return _cantileverRight;
            }
            set
            {
                _cantileverRight = value;

                _errorsViewModel.ClearErrors(nameof(CantileverRight));
                if (CantileverRight.Contains('.') || CantileverRight.Contains(',') || CantileverRight.Any(Char.IsLetter))
                {
                    _errorsViewModel.AddError(nameof(CantileverRight), "Niepoprawny format. Podaj wymiary w mm");
                }

                OnPropertyChanged(nameof(CantileverRight));
                OnPropertyChanged(nameof(BeamLength));

                beamDimension.CantileverRight = int.Parse(_cantileverRight);
                _beamDimensionStore.BeamDimension = beamDimension;
            }
        }

        private string _spanOne = "0";

        public string SpanOne
        {
            get
            {
                return _spanOne;
            }
            set
            {
                _spanOne = value;

                _errorsViewModel.ClearErrors(nameof(SpanOne));
                if (SpanOne.Contains('.') || SpanOne.Contains(',') || SpanOne.Any(Char.IsLetter))
                {
                    _errorsViewModel.AddError(nameof(SpanOne), "Niepoprawny format. Podaj wymiary w mm");
                }

                OnPropertyChanged(nameof(SpanOne));
                OnPropertyChanged(nameof(BeamLength));

                beamDimension.SpanOne = int.Parse(_spanOne);
                _beamDimensionStore.BeamDimension = beamDimension;
            }
        }

        private int _beamLength => int.Parse(CantileverRight) + int.Parse(CantileverRight) + int.Parse(SpanOne);
        public int BeamLength
        {
            get { return _beamLength; }
            set
            {               
            }

        }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public DimensionComponentViewModel(BeamDimensionStore beamDimensionStore)
        {
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            this._beamDimensionStore = beamDimensionStore; 
        }

        //errors

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

    }
}
