using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDigits.Enumerations
{
    public enum CalculatorOperation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply,
        Percented,
        SquareRoot,
        PowerByTwo

    }
    public static class CalculatorOperationExtensions
    {
        public static string ToSymbolString(this CalculatorOperation operation)
        {
            switch (operation)
            {
                case CalculatorOperation.Add: return "+";
                case CalculatorOperation.Subtract: return "-";
                case CalculatorOperation.Divide: return "/";
                case CalculatorOperation.Multiply: return "*";
                case CalculatorOperation.Percented: return "%";
                case CalculatorOperation.SquareRoot: return "√";
                case CalculatorOperation.PowerByTwo: return "2x";
                default: return string.Empty;
            }
        }
        public static CalculatorOperation GetOperationFromString(string operationString)
        {
            switch (operationString)
            {
                case "+": return CalculatorOperation.Add;
                case "-": return CalculatorOperation.Subtract;
                case "/": return CalculatorOperation.Divide;
                case "*": return CalculatorOperation.Multiply;
                case "%": return CalculatorOperation.Percented;
                case "√": return CalculatorOperation.SquareRoot;
                case "2x": return CalculatorOperation.PowerByTwo;
                default: return CalculatorOperation.None;
            }
        }
    }
}
