using Microsoft.Extensions.Logging;
using RegistroEstudiantesMVVM.ViewModels;
using RegistroEstudiantesMVVM.Views;

namespace RegistroEstudiantesMVVM
{
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

            // Registro de dependencias MVVM (Inyección de dependencias)
            builder.Services.AddTransient<RegistroViewModel>();
            builder.Services.AddTransient<RegistroPage>();

            return builder.Build();
        }
    }
}
