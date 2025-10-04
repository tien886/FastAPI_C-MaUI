using MathOperations.ViewModels;

namespace MathOperations.Views;

public partial class ManHinhChoView : ContentPage
{
	public ManHinhChoView(ManHinhChoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
}
}