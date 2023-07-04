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

namespace BeamCalculatorOneSpanApp.Commands
{
    public class GenerateChartsCommand : CommandBase
    {
        //private readonly CalculatorManager _calculatorManager;
        private readonly ElementViewModel _elementViewModel;

        private readonly TestCalculator _testCalculator;
        private readonly TestStore _testStore;

        public GenerateChartsCommand(ElementViewModel elementViewModel, TestStore testStore)
        {
            //_calculatorManager = new CalculatorManager();
            _elementViewModel = elementViewModel;
            _elementViewModel.PropertyChanged += OnViewModelPropertyChanged;

            _testCalculator = new TestCalculator();
            _testStore = testStore;





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

            Element element = _elementViewModel.BeamPickerComponentViewModel.SelectedElement;

            string nazwa = _testCalculator.Test(element);
            TestItem testItem = new TestItem(nazwa);

            try
            {
                _testStore.TestItem = testItem;
            }
            catch (Exception)
            {
               
            }
            

            //List<LoadPoint> loadPoint = _elementViewModel.ListLoadPoint.ToList();
            //List<LoadDistributed> loadDistributed = _elementViewModel.ListLoadDistributed.ToList();
            //Element element = _elementViewModel.SelectedElement;
            //BeamData beamData = new BeamData(int.Parse(_elementViewModel.CantileverLeft), int.Parse(_elementViewModel.CantileverRight), int.Parse(_elementViewModel.SpanOne));

            //try
            //{

            //    _calculatorManager.Calculate(element, beamData, loadPoint, loadDistributed);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Błąd. Podaj dane ponownie");
            //}
        }
    }
}
