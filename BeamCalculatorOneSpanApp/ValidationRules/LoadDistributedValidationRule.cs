using BeamCalculatorOneSpanApp.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;

namespace BeamCalculatorOneSpanApp.ValidationRules
{
    public class LoadDistributedValidationRule : ValidationRule
    {
        public BeamLengthWrapper BeamLengthWrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            LoadDistributed? loadDistributed = ((BindingGroup)value).Items[0] as LoadDistributed;
            if (loadDistributed.StartPosition > this.BeamLengthWrapper.BeamLength 
                || loadDistributed.EndPosition > this.BeamLengthWrapper.BeamLength)
            {
                return new ValidationResult(false,
                    "Przekracza długośc belki");
            }
            else if (loadDistributed.StartPosition >= loadDistributed.EndPosition)
            {
                return new ValidationResult(false,
                                    "Punkt początkowy nie może przekraczać punktu końcowego");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }
}
