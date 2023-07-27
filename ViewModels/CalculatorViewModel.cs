using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickDigits.Enumerations;
using QuickDigits.Services;

namespace QuickDigits.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
        private string _firstValue;
        private string _secondValue;
        private string _currentValue;
        private double _currentResult;
        private CalculatorOperation _currentOperation;
        private bool _isOperationClicked;
        CalculatorService _calculatorService;
        [ObservableProperty]
        private string result;
        public CalculatorViewModel(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;          
            Result = "0";
        }
        [RelayCommand]
        private void GetResult(object sender)
        {
            if (_calculatorService._secondValue == 0)            
                _calculatorService._secondValue = _calculatorService.ParseValue(_calculatorService._currentValue);                               
           
            _calculatorService.GetResult();
            Result = _calculatorService.Result;           
            RestValue();
        }
        [RelayCommand]
        void ClearResult(object sender)
        {
            Result = "0";
            RestValue();
            _currentOperation = CalculatorOperation.None;
            _isOperationClicked = false;
            _currentResult = 0;
        }
        [RelayCommand]
        void Calcurate(object sender)
        {
            _calculatorService.Calculate(sender.ToString());
            Result = _calculatorService.Result;
            
        }
        [RelayCommand]
        void SetNumbers(object sender)
        {
            _calculatorService.SetNumbers((string)sender);
            Result = _calculatorService.Result;
        }
        [RelayCommand]
        void ExtraCalculator(object sender)
        {
            string operation = sender.ToString();
            if (_currentResult == 0)
                _currentResult = Convert.ToDouble(_currentValue);
            switch (operation)
            {
                case "2x":
                    _currentResult *= 2;
                    break;
                case "√":
                    _currentResult = Math.Sqrt(_currentResult);
                    break;
            }
            Result = _currentResult.ToString();
        }      
      
        private void RestValue()
        {
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _currentValue = string.Empty;
        }
    }
}