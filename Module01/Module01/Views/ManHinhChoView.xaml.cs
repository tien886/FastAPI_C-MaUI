using Module01.ViewModels;

namespace Module01.Views;

public partial class ManHinhChoView : ContentPage
{
	public ManHinhChoView(ManHinhChoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
}
}