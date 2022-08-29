using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class CalculatorEngine
    {
        //vamos executar aqui a lógica das operações
        public double Calculate(string argOperation, double argFirstNumber, double argSecondNumber)
        {
            double result;

            switch (argOperation.ToLower())
            {
                //adição
                case "add":
                case "+":
                    result = argFirstNumber + argSecondNumber;
                    break;
                //subtração
                case "subtract":
                case "-":
                    result = argFirstNumber - argSecondNumber;
                    break;
                //multiplicação
                case "multiply":
                case "*":
                    result = argFirstNumber * argSecondNumber;
                    break;
                //divisão
                case "divide":
                case "/":
                    result = argFirstNumber / argSecondNumber;
                    break;
                //em caso de não ser reconhecido o input = não ser um dos casos
                default:
                    throw new InvalidOperationException("Specified operation is not recognized"); 
            }

            return result;
        }
    }
}
