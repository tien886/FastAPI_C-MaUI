
using MathOperations.ViewModels;
using MathOperations.Views;

namespace MathOperations.DI;

public static class AppModule
{
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        services.AddTransient<ManHinhChoView>();
        services.AddTransient<ManHinhChoViewModel>();
        return services;
    }
}
