using AppShellSplitScreen.ViewModel;

namespace AppShellSplitScreen.View;

public partial class NewPage3 : ContentPage
{
	public NewPage3(NewPage3ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}