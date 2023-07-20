using BeamCalculatorOneSpanApp.Models.BeamInfo;
using BeamCalculatorOneSpanApp.Models.Loader;
using BeamCalculatorOneSpanApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.ViewModels
{
    public class BeamPickerComponentViewModel : ViewModelBase
    {
        private ElementStore _elementStore;
        private ObservableCollection<Element> _listOfElements { get; set; }

        public BeamPickerComponentViewModel(Stores.ElementStore elementStore) 
        {
            FileLoader _fileLoader = new FileLoader();
            _listOfElements = new ObservableCollection<Element>(_fileLoader.getElementsList());

            _elementStore = elementStore;
        }

        public List<string> CategoryNames
        {
            get
            {
               return _listOfElements.Select(x => x.Category).Distinct().ToList();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                OnPropertyChanged(nameof(ListOfElementsWithSelectedCategory));
            }
        }

        public List<Element> ListOfElementsWithSelectedCategory
        {
            get
            {
                if (SelectedCategory != null)
                {
                    return _listOfElements.Where(x => x.Category == SelectedCategory.ToString()).ToList();
                }
                return null;
            }
        }

        private Element _selectedElement;
        public Element SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                OnPropertyChanged(nameof(SelectedElement));

                _elementStore.Element = _selectedElement;
            }
        }
    }
}
