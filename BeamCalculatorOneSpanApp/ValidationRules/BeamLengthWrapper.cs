using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCalculatorOneSpanApp.ValidationRules
{
    public class BeamLengthWrapper : DependencyObject
    {
        public static readonly DependencyProperty BeamLengthProperty =
         DependencyProperty.Register(
         nameof(BeamLength),
         typeof(int),
         typeof(BeamLengthWrapper),
         //new FrameworkPropertyMetadata(int.MaxValue));
         new PropertyMetadata(default(int)));

        public int BeamLength
        {
            get { return (int)GetValue(BeamLengthProperty); }
            set { SetValue(BeamLengthProperty, value); }
        }
    }
}
