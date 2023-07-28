using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickDigits.Services;

namespace QuickDigits.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
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
           
            _calculatorService.GetResult(sender.ToString());
            Result = _calculatorService.Result;           
           
        }
        [RelayCommand]
        void ClearResult(object sender)
        {
            Result = "0";
            _calculatorService.ClearResult();
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
            _calculatorService.ExtraCalculator(sender.ToString());           
            Result = _calculatorService.Result;
        }    
    }
}