
using CaptureFace.Views;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CaptureFace.ViewModels;
    
public partial class ManHinhChoViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    public ManHinhChoViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    [RelayCommand]
    public async Task StartCamera()
    {
        var chupKhuonMatViewModel = _serviceProvider.GetRequiredService<ChupKhuonMatViewModel>();
        var newpopup = new ChupKhuonMatView(chupKhuonMatViewModel);
        var mainpage = Application.Current?.MainPage;
        if (mainpage != null)
            await mainpage.ShowPopupAsync(newpopup);
    }
}
