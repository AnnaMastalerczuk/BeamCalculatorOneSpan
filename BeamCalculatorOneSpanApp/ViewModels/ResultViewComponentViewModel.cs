using BeamCalculator.Models.Calculator;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class ResultViewComponentViewModel : ViewModelBase
    {
        private readonly LoadPointListStore _loadPointListStore;
        
        // T forces list of points
        public List<Point> _listOfPointsTForces;
        public IEnumerable<Point> ListOfPointsTForces => _listOfPointsTForces;

        // M forces list of points
        public List<Point> _listOfPointsMForces;
        public IEnumerable<Point> ListOfPointsMForces => _listOfPointsMForces;



        public ResultViewComponentViewModel(LoadPointListStore loadPointListStore)
        {
            _loadPointListStore = loadPointListStore;

            _loadPointListStore.LoadPointListSaved += LoadPointListStore_LoadPointListSaved;

            _listOfPointsTForces = new List<Point>();            
        }
        protected override void Dispose()
        {
            _loadPointListStore.LoadPointListSaved -= LoadPointListStore_LoadPointListSaved;
            base.Dispose();
        }

        private void LoadPointListStore_LoadPointListSaved(List<Point> listT, List<Point> listM)
        {
            _listOfPointsTForces = listT;
            _listOfPointsMForces = listM;
            OnPropertyChanged(nameof(ListOfPointsTForces));
            OnPropertyChanged(nameof(ListOfPointsMForces));
        }


    }
}
