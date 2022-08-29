using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class InputConverter
    {
        //para tentar converter os inputs dados
        public double ConvertInputToNumeric(string argTextInput)
        {
            double convertedNumber;
            if (!double.TryParse(argTextInput, out convertedNumber))
                throw new ArgumentException("Expected a numeric value.");
            return convertedNumber;
        }
    }
}
