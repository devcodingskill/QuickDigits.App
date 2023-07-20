using QuickDigits.ViewModels;

namespace QuickDigits.Views;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage(CalculatorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}