using QuickDigits.Enumerations;

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
                if (_firstValue == 0)
                {
                    _firstValue = ParseValue(Result);
                    _currentOperation = CalculatorOperationExtensions.GetOperationFromString(operation);
                    _isOperationClicked = true;
                    _currentValue = string.Empty;
                    Result = $"{_firstValue} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
                }
                else
                {
                    _currentOperation = CalculatorOperationExtensions.GetOperationFromString(operation);
                    Result = $"{_currentResult} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
                }
            }
            else
            {
                _currentOperation = CalculatorOperationExtensions.GetOperationFromString(operation);
                Result = $"{_currentResult} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)}";
            }
        }

        public void SetNumbers(string input)
        {
            if (_currentResult == 0)           
                FirstTimeInput(input);            
            else            
                SecondTimeInput(input);            
        }
        public void ExtraCalculator(string operation)
        {
            _currentOperation = CalculatorOperationExtensions.GetOperationFromString(operation);
            if (_currentResult == 0)
                _currentResult = ParseValue(Result);

            switch (_currentOperation)
            {
                case CalculatorOperation.PowerByTwo:
                    _currentResult *= 2;
                    break;
                case CalculatorOperation.SquareRoot:
                    _currentResult = Math.Sqrt(_currentResult);
                    break;
            }
            Result = _currentResult.ToString();
        }

        public void GetResult(string? operation = null)
        {
            if (string.IsNullOrEmpty(Result))
                return;

            if (CalculatorOperationExtensions.GetOperationFromString(operation) == CalculatorOperation.Percented)
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
                case CalculatorOperation.Add:
                    _currentResult = _firstValue + (_firstValue * _secondValue / 100);
                    break;
            }
        }

        private void SecondTimeInput(string input)
        {
            _firstValue = _currentResult;
            _currentValue += input;
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
                _currentValue += input;
                Result = $"{_firstValue} {CalculatorOperationExtensions.ToSymbolString(_currentOperation)} {_currentValue} ";
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
        public double ParseValue(string input)
        {
            double value;
            if (double.TryParse(input, out value))
                return value;

            return 0;
        }
    }
}
