using BeamCalculatorOneSpanApp.Stores;
using BeamCalculatorOneSpanApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCalculatorOneSpanApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly BeamDimensionStore _beamDimensionStore;
        private readonly LoadPointListStore _loadPointListStore;
        private readonly ElementStore _elementStore;

        public App()
        {
            _beamDimensionStore = new BeamDimensionStore();
            _loadPointListStore = new LoadPointListStore();
            _elementStore = new ElementStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ElementViewModel(_beamDimensionStore, _loadPointListStore, _elementStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
