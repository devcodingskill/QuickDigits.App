using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QuickDigits.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
        private string _firstValue;
        private string _secondValue;
        private string _temValue;
        private double _temSumValue;
        private string _calcurat;
        private bool _calcuratClick;
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
                _secondValue = _temValue;

            GetTheResult();
            Result = _temSumValue.ToString();
            RestValue();
        }
        [RelayCommand]
        void ClearResult(object sender)
        {
            Result = "0";
            RestValue();
            _calcurat = string.Empty;
            _calcuratClick = false;
            _temSumValue = 0;
        }
        [RelayCommand]
        void Calcurate(object sender)
        {

            if (string.IsNullOrEmpty(_temSumValue.ToString()) || _temSumValue.ToString().Equals("0"))
            {
                if (string.IsNullOrEmpty(_firstValue))
                {
                    _firstValue = _temValue;
                    _temValue = string.Empty;
                    _calcurat = sender.ToString();
                    _calcuratClick = true;
                    Result = _firstValue + "" + _calcurat;
                }
                else
                {
                    _calcurat = sender.ToString();
                    Result = _temSumValue.ToString() + "" + _calcurat;
                }
            }
            else
            {
                _calcurat = sender.ToString();
                Result = _temSumValue.ToString() + "" + _calcurat;
            }
        }
        [RelayCommand]
        void SetNumbers(object sender)
        {
            if (string.IsNullOrEmpty(_temSumValue.ToString()) || _temSumValue.ToString().Equals("0"))
            {
                FirstTimeInput(sender);
            }
            else
            {
                SecondeTimeInput(sender);
            }
        }

        private void SecondeTimeInput(object sender)
        {
            if (string.IsNullOrEmpty(_firstValue))
            {
                _firstValue = _temSumValue.ToString();
            }
            _temValue += sender.ToString();
            Result = _firstValue + "" + _calcurat + _temValue;
        }

        private void FirstTimeInput(object sender)
        {
            if (!_calcuratClick)
            {
                _temValue += sender.ToString();
                Result = _temValue;
            }
            else
            {
                _temValue += sender.ToString();
                Result = _firstValue + "" + _calcurat + _temValue;
            }
        }
        private void GetTheResult()
        {
            switch (_calcurat)
            {
                case "+":
                    _temSumValue = Convert.ToDouble(_firstValue) + Convert.ToDouble(_secondValue);
                    break;
                case "-":
                    _temSumValue = Convert.ToDouble(_firstValue) - Convert.ToDouble(_secondValue);
                    break;
                case "/":
                    _temSumValue = Convert.ToDouble(_firstValue) / Convert.ToDouble(_secondValue);
                    break;
                case "*":
                    _temSumValue = Convert.ToDouble(_firstValue) * Convert.ToDouble(_secondValue);
                    break;
            }
        }
        private void RestValue()
        {
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _temValue = string.Empty;
        }
    }
}
