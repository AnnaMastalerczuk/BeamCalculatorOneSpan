using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BeamCalculatorOneSpanApp.ValidationRules
{
    public class LoadPointValidationRule : ValidationRule
    {
        public BeamLengthWrapper BeamLengthWrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            LoadPoint? loadPoint = ((BindingGroup)value).Items[0] as LoadPoint;
            if (loadPoint.StartPosition > this.BeamLengthWrapper.BeamLength)
            {
                return new ValidationResult(false,
                    "Przekracza długośc belki");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }
}
