using BeamCalculator.Models.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Stores
{
    public class LoadPointListStore
    {
        public event Action<List<Point>, List<Point>> LoadPointListSaved;

        public void Save(List<Point> listT, List<Point> listM)
        {
            LoadPointListSaved?.Invoke(listT, listM);
        }
    }
}
