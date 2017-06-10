using System;
using System.Globalization;
using System.Windows.Controls;

namespace FoodCalculatorGui
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int result = 0;
            bool canConvert = int.TryParse(value as string, out result);
            if (canConvert)
                canConvert = result > 0;
            return new ValidationResult(canConvert, "Not a valid value");
        }
    }
}