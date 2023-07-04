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
        private TestStore _testStore;
        public string Nazwa => _testStore.TestItem?.Nazwa ?? "nie ma";
        public ResultViewComponentViewModel(TestStore _testStore)
        {
            this._testStore = _testStore;
            //_testStore.TestItem += TestStore_TestItemChanged;
        }

        //protected override void Dispose()
        //{
        //    _testStore.TestItem -= TestStore_TestItemChanged;
        //    base.Dispose();
        //}

        //private void TestStore_TestItemChanged()
        //{
        //    OnPropertyChanged(nameof(Nazwa));
        //}

    }
}
