using Microsoft.Extensions.Logging;
using MathOperation.DI;
using MathOperation;

namespace MathOperation
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
            builder.Services.RegisterDependency();
            var appBuilder = builder.Build();
            _ = Task.Run(async () =>
            {
                using var scope = appBuilder.Services.CreateScope();
            }
                );
            return appBuilder;
        }
    }
}
