
using CaptureFace.ViewModels;
using CaptureFace.Views;

namespace CaptureFace.DI;

public static class AppModule
{
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        services.AddTransient<ChupKhuonMatView>();
        services.AddTransient<ManHinhChoView>();
        services.AddTransient<ChupKhuonMatViewModel>();
        services.AddTransient<ManHinhChoViewModel>();
        return services;
    }
}
