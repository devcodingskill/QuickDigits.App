using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QuickDigits.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
        private string _firstValue;
        private string _secondValue;
        private string _currentValue;
        private double _currentResult;
        private CalculatorOperation _currentOperation;
        private string _currentOperation;
        private bool _isOperationClicked;
        [ObservableProperty]
        private string result;
        public CalculatorViewModel()
        {
            Result = "0";
        }
        [RelayCommand]
        private void GetResult(object sender)
        {
            //case: user already calculation so we need to get second value from user input in this case _temValue
            if (string.IsNullOrEmpty(_secondValue))
                _secondValue = _currentValue;

            PerformCalculation();
            Result = _currentResult.ToString();
            RestValue();
        }
        [RelayCommand]
        void ClearResult(object sender)
        {
            Result = "0";
            RestValue();
            _currentOperation = string.Empty;
            _isOperationClicked = false;
            _currentResult = 0;
        }
        [RelayCommand]
        void Calcurate(object sender)
        {

            if (string.IsNullOrEmpty(_currentResult.ToString()) || _currentResult.ToString().Equals("0"))
            {
                if (string.IsNullOrEmpty(_firstValue))
                {
                    _firstValue = _currentValue;
                    _currentValue = string.Empty;
                    _currentOperation = sender.ToString();
                    _isOperationClicked = true;
                    Result = _firstValue + "" + _currentOperation;
                }
                else
                {
                    _currentOperation = sender.ToString();
                    Result = _currentResult.ToString() + "" + _currentOperation;
                }
            }
            else
            {
                _currentOperation = sender.ToString();
                Result = _currentResult.ToString() + "" + _currentOperation;
            }
        }
        [RelayCommand]
        void SetNumbers(object sender)
        {
            if (string.IsNullOrEmpty(_currentResult.ToString()) || _currentResult.ToString().Equals("0"))
            {
                FirstTimeInput(sender);
            }
            else
            {
                SecondeTimeInput(sender);
            }
        }
        [RelayCommand]
        void ExtraCalculator(object sender)
        {
            string operation = sender.ToString();

        }
        private void SecondeTimeInput(object sender)
        {
            if (string.IsNullOrEmpty(_firstValue))
            {
                _firstValue = _currentResult.ToString();
            }
            _currentValue += sender.ToString();
            Result = _firstValue + "" + _currentOperation + _currentValue;
        }

        private void FirstTimeInput(object sender)
        {
            if (!_isOperationClicked)
            {
                _currentValue += sender.ToString();
                Result = _currentValue;
            }
            else
            {
                _currentValue += sender.ToString();
                Result = _firstValue + "" + _currentOperation + _currentValue;
            }
        }
        private void PerformCalculation()
        {
            switch (_currentOperation)
            {
                case "+":
                    _currentResult = Convert.ToDouble(_firstValue) + Convert.ToDouble(_secondValue);
                    break;
                case "-":
                    _currentResult = Convert.ToDouble(_firstValue) - Convert.ToDouble(_secondValue);
                    break;
                case "/":
                    _currentResult = Convert.ToDouble(_firstValue) / Convert.ToDouble(_secondValue);
                    break;
                case "*":
                    _currentResult = Convert.ToDouble(_firstValue) * Convert.ToDouble(_secondValue);
                    break;
            }
        }
        private void RestValue()
        {
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _currentValue = string.Empty;
        }
    }
    public enum CalculatorOperation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply
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
                default: return string.Empty;
            }
        }
    }
}