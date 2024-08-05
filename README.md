# .NET MAUI AppShell Split Screen

This application demonstrates how to divide a device screen into regions where one half is showing static content while the other half navigates through pages as you would expect with AppShell Navigation. This might be useful for tablet devices where the user would see a static map on one side and normal app navigation on the other.

## How it Works
We define a singular ShellContent within our AppShell with two ContentViews. Both ContentViews are loaded with the content of ContentPages at startup. The top ContentView is updated as pages are navigated to while the bottom ContentView remains the same.
In the AppShell codebehind, we override the OnNavigating method to intercept normal Shell Navigation and transplant the contents of the ContentPage into the ContentView. The BindingContext of this ContentView is also updated with the ViewModel bound to the ContentPage being navigated to.

### AppShell.xaml
```xaml
<Shell
    x:Class="AppShellSplitScreen.AppShell"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:local="clr-namespace:AppShellSplitScreen"
    Title="AppShellSplitScreen"
    Shell.FlyoutBehavior="Disabled">

    <ShellContent>
        <ContentPage Shell.NavBarHasShadow="False">
            <Grid RowDefinitions="*,*">
                <!--
                    As the app uses AppShell to navigate we override OnNavigating in the codebehind and
                    render the pages in this ContentView.
                -->
                <ContentView x:Name="ContentArea" />
                <!--
                    This is the static view that will be shown in the bottom half of the screen.
                -->
                <ContentView Grid.Row="1" x:Name="StaticContentArea" />

            </Grid>
        </ContentPage>
    </ShellContent>

</Shell>
```
### AppShell.xaml.cs
```csharp
        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // Cancel the default shell navigation
            args.Cancel();

            var targetRoute = args.Target.Location.OriginalString.TrimStart('/');

            // Handle back navigation manually
            // TODO: Handle other AppShell navigation such as going back multiple pages.
            if (_navigationStack.Count > 1 && targetRoute == "..")
            {
                _navigationStack.Pop();
                var previousPage = _navigationStack.Peek();
                LoadPage(previousPage, false);
                return;
            }

            LoadPage(targetRoute);
        }

        private void LoadPage(string pageName, bool addToStack = true)
        {
            var pageType = Type.GetType($"{typeof(AppShell).Namespace}.View.{pageName}");
            if (pageType == null || !typeof(ContentPage).IsAssignableFrom(pageType))
            {
                Debug.WriteLine($"Could not find type {pageName} from route.");
                return;
            }

            var page = App.ServiceProvider.GetService(pageType) as ContentPage;
            if (page == null)
            {
                Debug.WriteLine($"Could not resolve page instance for type: {pageType}");
                return;
            }
            
            ContentArea.Content = page.Content;
            ContentArea.BindingContext = page.BindingContext;
            if (addToStack)
            {
                _navigationStack.Push(pageName);
            }
        }
```

Because we are intercepting and cancelling AppShell navigation we do not have the normal AppShell stack to use and we need to manage a stack manually. We respond to normal AppShell back navigation commands by examining our own stack and changing to the appropriate page.

To demonstrate the static property of the bottom ContentView a PageService is created to allow communication between the static page and the navigation pages.

We can also operate the application using normal AppShell by using AppShellNoSplit at startup. With this no split AppShell the pages will be navigated to normally.

# App.xaml.cs
```csharp
            // Use AppShellNoSplit to see normal AppShell behavior
            MainPage = new AppShellNoSplit();
```
