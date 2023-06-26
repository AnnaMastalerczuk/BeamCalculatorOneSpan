using BeamCalculatorOneSpanApp.Models.BeamInfo;
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
        //private BeamDimension _beamDimension;
        //public BeamDimension BeamDimension
        //{
        //    get { return _beamDimension; }
        //    set 
        //    {
        //        _beamDimension = value;
        //        OnPropertyChanged(nameof(BeamDimension));
        //    }
        //}
        private readonly ErrorsViewModel _errorsViewModel;

        //Dimensions
        private string _cantileverLeft;
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
            }
        }


        private string _cantileverRight;
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
            }
        }

        private string _spanOne;
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

            }
        }

        private int _beamLength;
        public int BeamLength
        {
            get { return int.Parse(CantileverRight) + int.Parse(CantileverRight) + int.Parse(SpanOne); }

        }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public DimensionComponentViewModel()
        {
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }
        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            //OnPropertyChanged(nameof(CanCreate));
        }


    }
}
