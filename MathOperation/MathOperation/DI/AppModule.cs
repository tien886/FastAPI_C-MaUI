
using MathOperation.ViewModels;
using MathOperation.Views;

namespace MathOperation.DI;

public static class AppModule
{
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        services.AddTransient<ManHinhChoView>();
        services.AddTransient<ManHinhChoViewModel>();
        return services;
    }
}
