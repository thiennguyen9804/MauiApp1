using MauiApp1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace MauiApp1;

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
        builder.Services.AddSingleton(new HttpClient
        {
            BaseAddress = new Uri("10.0.2.2")
        });

        builder.Services.AddSingleton<ITodoApiService, TodoApiService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        

        return builder.Build();
    }
}