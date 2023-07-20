using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BeamCalculatorOneSpanApp.Help
{
    public class NumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Sprawdź, czy wartość jest liczbą
            if (value is double number)
            {
                // Pobierz liczbę miejsc po przecinku z parametru konwertera (jeśli został podany)
                int decimalPlaces = 2; // Domyślnie 2 miejsca po przecinku
                if (parameter != null && int.TryParse(parameter.ToString(), out int places))
                {
                    decimalPlaces = places;
                }

                // Sformatuj liczbę z odpowiednią liczbą miejsc po przecinku
                return number.ToString("N" + decimalPlaces, CultureInfo.CurrentCulture);
            }

            return value; // Zwróć oryginalną wartość, jeśli nie jest liczbą
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
