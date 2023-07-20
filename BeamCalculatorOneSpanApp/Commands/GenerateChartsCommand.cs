using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
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
        private readonly CalculateReactionsOneSpan _calculateReactionsOneSpan;
        private readonly ElementViewModel _elementViewModel;
        private readonly BeamDimensionStore _beamDimensionStore;
        private readonly LoadPointListStore _loadPointListStore;     

        public GenerateChartsCommand(ElementViewModel elementViewModel, BeamDimensionStore beamDimensionStore, LoadPointListStore loadPointListStore)
        {
            _calculatorManager = new CalculatorManager();
            _calculateReactionsOneSpan = new CalculateReactionsOneSpan();
            _elementViewModel = elementViewModel;
            _beamDimensionStore = beamDimensionStore;
            _loadPointListStore = loadPointListStore;

            _elementViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        { 
            if (e.PropertyName == nameof(ElementViewModel.CanGenerateCharts))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _elementViewModel.CanGenerateCharts &&
                base.CanExecute(parameter);

        }
        public override void Execute(object? parameter)
        {
            List<LoadPoint> loadPoint = _elementViewModel.LoadPointListComponentViewModel.ListLoadPoint.ToList();
            List<LoadDistributed> loadDistributed = _elementViewModel.LoadDistributedListComponentViewModel.ListLoadDistributed.ToList();
            Element element = _elementViewModel.BeamPickerComponentViewModel.SelectedElement;
            BeamDimension beamData = _beamDimensionStore.BeamDimension;
           
            try
            {
                List<Point> listOfPointsT = new List<Point>();
                List<Point> listOfPointsM = new List<Point>();
                Dictionary<string, double> reactionsList = new Dictionary<string, double>();

                reactionsList = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
                listOfPointsT = _calculatorManager.CalculateTForces(element, beamData, loadPoint, loadDistributed, reactionsList);
                listOfPointsM = _calculatorManager.CalculateMForces(element, beamData, loadPoint, loadDistributed, reactionsList);
                _loadPointListStore.Save(listOfPointsT, listOfPointsM, reactionsList);
                _elementViewModel.ResultViewComponentViewModel.UpdateValues();

            }
            catch (Exception)
            {
                MessageBox.Show("Błąd. Podaj dane ponownie");
            }
        }
    }
}
