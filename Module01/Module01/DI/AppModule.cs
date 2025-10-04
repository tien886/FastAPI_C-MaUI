
using Module01.ViewModels;
using Module01.Views;

namespace Module01.DI;

public static class AppModule
{
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        services.AddTransient<ManHinhChoView>();
        services.AddTransient<ManHinhChoViewModel>();
        return services;
    }
}
