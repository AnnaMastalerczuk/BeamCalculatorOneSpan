using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculatorOneSpanApp.Stores
{
    public class ElementStore
    {
        private Element _element;
        public Element Element
        {
            get { return _element; }
            set
            {
                _element = value;
                ElementChanged?.Invoke();
            }
        }

        public event Action ElementChanged;

    }
}
