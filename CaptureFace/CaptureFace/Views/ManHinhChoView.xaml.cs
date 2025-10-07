using CaptureFace.ViewModels;

namespace CaptureFace.Views;

public partial class ManHinhChoView : ContentPage
{
	public ManHinhChoView(ManHinhChoViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}