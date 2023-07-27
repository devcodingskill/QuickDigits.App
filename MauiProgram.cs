using Microsoft.Extensions.Logging;
using QuickDigits.Services;
using QuickDigits.ViewModels;
using QuickDigits.Views;

namespace QuickDigits;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<CalculatorPage>();
        builder.Services.AddSingleton<CalculatorViewModel>();
		builder.Services.AddSingleton<CalculatorService>();
        return builder.Build();
	}
}
