using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Models.Calculator;
using BeamCalculatorOneSpanApp.Stores;
using BeamCalculatorOneSpanApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = BeamCalculator.Models.Calculator.Point;

namespace BeamCalculatorOneSpanApp.Commands
{
    public class GenerateChartsCommand : CommandBase
    {
        private readonly CalculatorManager _calculatorManager;
        private readonly ElementViewModel _elementViewModel;
        private readonly BeamDimensionStore _beamDimensionStore;
        private readonly LoadPointListStore _loadPointListStore;
     

        public GenerateChartsCommand(ElementViewModel elementViewModel, BeamDimensionStore beamDimensionStore, LoadPointListStore loadPointListStore)
        {
            _calculatorManager = new CalculatorManager();
            _elementViewModel = elementViewModel;
            _beamDimensionStore = beamDimensionStore;
            _loadPointListStore = loadPointListStore;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == nameof(ElementViewModel.SelectedElement) || e.PropertyName == nameof(ElementViewModel.SpanOne)
            //    || e.PropertyName == nameof(ElementViewModel.CantileverLeft) || e.PropertyName == nameof(ElementViewModel.CantileverRight))
            //{
            //    OnCanExecutedChanged();
            //}
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            //return _elementViewModel.SelectedElement != null && !string.IsNullOrEmpty(_elementViewModel.SpanOne)
            //    && !string.IsNullOrEmpty(_elementViewModel.CantileverLeft) && !string.IsNullOrEmpty(_elementViewModel.CantileverRight)
            //    && base.CanExecute(parameter);

            return true;

        }
        public override void Execute(object? parameter)
        {
            List<LoadPoint> loadPoint = _elementViewModel.LoadPointListComponentViewModel.ListLoadPoint.ToList();
                //List<LoadPoint> loadPoint = _elementViewModel.ListLoadPoint.ToList();
            List<LoadDistributed> loadDistributed = _elementViewModel.LoadDistributedListComponentViewModel.ListLoadDistributed.ToList();
                //List<LoadDistributed> loadDistributed = _elementViewModel.ListLoadDistributed.ToList();
            Element element = _elementViewModel.BeamPickerComponentViewModel.SelectedElement;
                //Element element = _elementViewModel.SelectedElement;
            BeamDimension beamData = _beamDimensionStore.BeamDimension;
            //BeamData beamData = new BeamData(int.Parse(_elementViewModel.CantileverLeft), int.Parse(_elementViewModel.CantileverRight), int.Parse(_elementViewModel.SpanOne));

            try
            {
                List<Point> listOfPointsT = new List<Point>();
                List<Point> listOfPointsM = new List<Point>();

                listOfPointsT = _calculatorManager.CalculateTForces(element, beamData, loadPoint, loadDistributed);
                listOfPointsM = _calculatorManager.CalculateMForces(element, beamData, loadPoint, loadDistributed);
                _loadPointListStore.Save(listOfPointsT, listOfPointsM);
                _elementViewModel.ResultViewComponentViewModel.UpdateValues();


            }
            catch (Exception)
            {
                MessageBox.Show("Błąd. Podaj dane ponownie");
            }
        }
    }
}
