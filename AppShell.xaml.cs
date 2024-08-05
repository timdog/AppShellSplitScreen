using AppShellSplitScreen.View;
using System.Diagnostics;

namespace AppShellSplitScreen
{
    public partial class AppShell : Shell
    {
        private readonly Stack<string> _navigationStack = new Stack<string>();

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewPage1), typeof(NewPage1));
            Routing.RegisterRoute(nameof(NewPage2), typeof(NewPage2));
            Routing.RegisterRoute(nameof(NewPage3), typeof(NewPage3));
            LoadPage(nameof(NewPage1));
            LoadStaticContent();
        }

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

        private void LoadStaticContent()
        {
            var staticPage = App.ServiceProvider.GetService(typeof(StaticPage)) as ContentPage;
            if (staticPage == null)
            {
                Debug.WriteLine("Could not resolve page instance for StaticPage.");
                return;
            }

            StaticContentArea.Content = staticPage.Content;
            StaticContentArea.BindingContext = staticPage.BindingContext;
        }
    }
}
