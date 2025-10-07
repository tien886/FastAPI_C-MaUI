using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CaptureFace.ViewModels;

public partial class ChupKhuonMatViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider; 
    private Popup _currentpopup;
    public ChupKhuonMatViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }
    [ObservableProperty]
    public string mSSV = "";
    [ObservableProperty]
    public string tenSV = "";
    public void SetCurrentPopup(Popup popup)
    {
        _currentpopup = popup;
    }
    [RelayCommand]
    public async Task ClosePopup()
    {
        if(_currentpopup != null)
            _currentpopup.Close();
    }
    

    // 2️⃣ Handle when capture finished
    
}
