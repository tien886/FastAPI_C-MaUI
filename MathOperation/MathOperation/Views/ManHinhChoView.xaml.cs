using MathOperation.ViewModels;

namespace MathOperation.Views;

public partial class ManHinhChoView : ContentPage
{
    public ManHinhChoView(ManHinhChoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}