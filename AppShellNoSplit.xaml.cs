using AppShellSplitScreen.View;

namespace AppShellSplitScreen;

public partial class AppShellNoSplit : Shell
{
	public AppShellNoSplit()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(NewPage2), typeof(NewPage2));
        Routing.RegisterRoute(nameof(NewPage3), typeof(NewPage3));
    }
}