using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Validation
    {
        public bool ValidateName(string nameToValidate)
        {
            string nameRules = @"^\w*$";
            if (Regex.IsMatch(nameToValidate, nameRules))
            {
                return true;
            }
            else
                return false;
        }

        public bool ValidateWholeNumber(string numToValidate)
        {
            string wholeNumberRules = @"^\d{2}$";
            if (Regex.IsMatch(numToValidate, wholeNumberRules))
            {
                return true;
            }
            else
                return false;
        }

        public bool ValidateDecimalNumbers(string decimalToValidate)
        {
            string decimalRules = @"^\d{2}.\d*$";
            if (Regex.IsMatch(decimalToValidate, decimalRules))
            {
                return true;
            }
            else
                return false;
        }
    }
}
