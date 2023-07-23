using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using System.Collections.ObjectModel;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System.Windows.Media;
using LiveCharts.Wpf;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class ResultViewComponentViewModel : ViewModelBase
    {

        private readonly LoadPointListStore _loadPointListStore;
        private readonly ElementStore _elementStore;

        // T forces list of points
        public List<Point> _listOfPointsTForces;
        public IList<Point> ListOfPointsTForces => _listOfPointsTForces;

        // M forces list of points
        public List<Point> _listOfPointsMForces;
        public IEnumerable<Point> ListOfPointsMForces => _listOfPointsMForces;

        // Reactions list
        public Dictionary<string, double> _listOfReactions;
        public double V1Value => _listOfReactions?.GetValueOrDefault("V1") ?? 0.0;
        public double V2Value => _listOfReactions?.GetValueOrDefault("V2") ?? 0.0;


        // List of T points to chart

        private ChartValues<double> _chartValuesT;
        public ChartValues<double> ChartValuesT
        {
            get
            {
                return _chartValuesT;
            }
            private set
            {
                _chartValuesT = value;
                OnPropertyChanged(nameof(ChartValuesT));
            }
        }
        public ObservableCollection<double> XPositionT { get; }

        // List of M points to chart

        private ChartValues<double> _chartValuesM;
        public ChartValues<double> ChartValuesM
        {
            get
            {
                return _chartValuesM;
            }
            private set
            {
                _chartValuesM = value;
                OnPropertyChanged(nameof(ChartValuesM));
            }
        }
        public ObservableCollection<double> XPositionM { get; }

        //max forces

        public double MaxTForce => ListOfPointsTForces?.Max(x => Math.Abs(x.Value)) ?? 0.0;
        public double MinTForce => ListOfPointsTForces?.Min(x => Math.Abs(x.Value)) ?? 0.0;
        public double MaxMForce => ListOfPointsMForces?.Max(x => Math.Abs(x.Value)) ?? 0.0;
        public double MinMForce => ListOfPointsMForces?.Min(x => Math.Abs(x.Value)) ?? 0.0;

        // max acceptable forces
        public double MaxAcceptableTForce => _elementStore.Element?.MaxT ?? 0.0;
        public double MaxAcceptableMForce => _elementStore.Element?.MaxM ?? 0.0;


        //ctor
        public ResultViewComponentViewModel(LoadPointListStore loadPointListStore, ElementStore elementStore)
        {
            _loadPointListStore = loadPointListStore;
            _elementStore = elementStore;

            _loadPointListStore.LoadPointListSaved += LoadPointListStore_LoadPointListSaved;

            XPositionT = new ObservableCollection<double>();
            ChartValuesT = new ChartValues<double>();

            XPositionM = new ObservableCollection<double>();
            ChartValuesM = new ChartValues<double>();
        }
        protected override void Dispose()
        {
            _loadPointListStore.LoadPointListSaved -= LoadPointListStore_LoadPointListSaved;
            base.Dispose();
        }

        private void LoadPointListStore_LoadPointListSaved(List<Point> listT, List<Point> listM, Dictionary<string, double> reactionsList)
        {
            _listOfPointsTForces = listT;
            _listOfPointsMForces = listM;
            _listOfReactions = reactionsList;


            OnPropertyChanged(nameof(ListOfPointsTForces));
            OnPropertyChanged(nameof(ListOfPointsMForces));
            OnPropertyChanged(nameof(V1Value));
            OnPropertyChanged(nameof(V2Value));

            OnPropertyChanged(nameof(MaxTForce));
            OnPropertyChanged(nameof(MinTForce));
            OnPropertyChanged(nameof(MaxMForce));
            OnPropertyChanged(nameof(MinMForce));
            OnPropertyChanged(nameof(MaxAcceptableTForce));
            OnPropertyChanged(nameof(MaxAcceptableMForce));
        }

        public void UpdateValues()
        {
            XPositionT.Clear();
            ChartValuesT.Clear();
            XPositionM.Clear();
            ChartValuesM.Clear();

            UpdateTValues();
            UpdateMValues();         

        }

        private void UpdateTValues()
        {
            foreach (Point point in _listOfPointsTForces)
            {
                ChartValuesT.Add(point.Value);
            }

            foreach (Point point in _listOfPointsTForces)
            {
                XPositionT.Add(point.X);
            }
        }

        private void UpdateMValues()
        {
            foreach (Point point in _listOfPointsMForces)
            {
                ChartValuesM.Add(point.Value);
            }

            foreach (Point point in _listOfPointsMForces)
            {
                XPositionM.Add(point.X);
            }
        }

    }
}
