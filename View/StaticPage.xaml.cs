using AppShellSplitScreen.ViewModel;

namespace AppShellSplitScreen.View;

public partial class StaticPage : ContentPage
{
	public StaticPage(StaticPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}