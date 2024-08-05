namespace AppShellSplitScreen
{
    public partial class App : Application
    {
        // Creating a static property to access the service provider from anywhere in the app.
        // This should only be necessary for the App.xaml.cs file since we cannot use DI in the constructor.
        public static IServiceProvider ServiceProvider { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            
            // Use AppShell to see split screen behavior which overrides normal AppShell behavior
            MainPage = new AppShell();

            // Use AppShellNoSplit to see normal AppShell behavior
            // MainPage = new AppShellNoSplit();
        }
    }
}
