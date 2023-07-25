using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickDigits.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDigits.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
        private int _firstValue;
        private int _secondValue;   
        private int _temSumValue;
        [ObservableProperty]
        private double result;
        public CalculatorViewModel()
        {
            Result = 0;            
        }
        [RelayCommand]
        private void GetResult(object sender) 
        {
           Result = 0;
        }
        [RelayCommand]
        void ClearResult(object sender)
        {
            Result = 0;
        }
        [RelayCommand]
        void Calcurate(object sender)
        {
            Result = 0;
        }
        [RelayCommand]
        void SetNumbers(object sender)
        {
            Result = 0;
        }

    }
}
