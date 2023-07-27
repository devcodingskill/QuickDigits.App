using QuickDigits.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDigits.Services
{
    public class CalculatorService
    {

        private double _currentResult;
        private double _firstValue;
        public double _secondValue;
        public string _currentValue;
        private CalculatorOperation _currentOperation;
        private bool _isOperationClicked;

        public string Result { get; private set; }

        public CalculatorService()
        {
            Result = "0";
        }

        public void ClearResult()
        {
            Result = "0";
            ResetValues();
            _currentOperation = CalculatorOperation.None;
            _isOperationClicked = false;
            _currentResult = 0;
           
        }

        public void Calculate(string operation)
        {
            if (_currentResult == 0)
            {
                if (_firstValue==0)
                {
                    _firstValue = ParseValue(Result);                   
                    _currentOperation = GetOperationFromString(operation);
                    _isOperationClicked = true;
                    Result = $"{_firstValue} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
                }
                else
                {
                    _currentOperation = GetOperationFromString(operation);
                    Result = $"{_currentResult} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
                }
            }
            else
            {
                _currentOperation = GetOperationFromString(operation);
                Result = $"{_currentResult} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
            }
        }

        public void SetNumbers(string input)
        {
            if (_currentResult == 0)
            {
                FirstTimeInput(input);
            }
            else
            {
                SecondTimeInput(input);
            }
        }

        public void ExtraCalculator(string operation)
        {
            if (_currentResult == 0)
                _currentResult = ParseValue(Result);

            switch (operation)
            {
                case "2x":
                    _currentResult *= 2;
                    break;
                case "√":
                    _currentResult = Math.Sqrt(_currentResult);
                    break;
                    // Add more operations if needed.
            }

            Result = _currentResult.ToString();
        }

        public void GetResult()
        {
            if (string.IsNullOrEmpty(Result))
                return;

            if (_currentOperation == CalculatorOperation.Percented)
                CalculatePercented();
            else
                PerformCalculation();

            Result = _currentResult.ToString();
            ResetValues();
        }

        private void CalculatePercented()
        {
            switch (_currentOperation)
            {
                case CalculatorOperation.Subtract:
                    _currentResult = _firstValue - (_firstValue * _secondValue / 100);
                    break;
                case CalculatorOperation.Multiply:
                    _currentResult = _firstValue + (_firstValue * _secondValue / 100);
                    break;
            }
        }

        private void SecondTimeInput(string input)
        {
            if (string.IsNullOrEmpty(_currentValue))
            {
                _firstValue = _currentResult;
                _currentValue = input;
            }

            Result = $"{_firstValue} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)} {_currentValue} ";
        }

        private void FirstTimeInput(string input)
        {
            if (!_isOperationClicked)
            {
                _currentValue += input;
                Result = _currentValue;
            }
            else
            {
                Result += input;
            }
        }

        private void PerformCalculation()
        {
            _secondValue = ParseValue(_currentValue);

            switch (_currentOperation)
            {
                case CalculatorOperation.Add:
                    _currentResult = _firstValue + _secondValue;
                    break;
                case CalculatorOperation.Subtract:
                    _currentResult = _firstValue - _secondValue;
                    break;
                case CalculatorOperation.Divide:
                    _currentResult = _firstValue / _secondValue;
                    break;
                case CalculatorOperation.Multiply:
                    _currentResult = _firstValue * _secondValue;
                    break;
            }
        }

        private void ResetValues()
        {
            _firstValue = 0;
            _secondValue = 0;
            _currentValue = string.Empty;
        }

        private CalculatorOperation GetOperationFromString(string operationString)
        {
            switch (operationString)
            {
                case "+": return CalculatorOperation.Add;
                case "-": return CalculatorOperation.Subtract;
                case "/": return CalculatorOperation.Divide;
                case "*": return CalculatorOperation.Multiply;
                case "%": return CalculatorOperation.Percented;
                default: return CalculatorOperation.None;
            }
        }

        public double ParseValue(string input)
        {
            double value;
            if (double.TryParse(input, out value))
                return value;

            return 0;
        }
    }
}
