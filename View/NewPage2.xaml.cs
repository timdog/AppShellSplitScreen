using AppShellSplitScreen.ViewModel;

namespace AppShellSplitScreen.View;

public partial class NewPage2 : ContentPage
{
	public NewPage2(NewPage2ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}