using AppShellSplitScreen.Services;
using AppShellSplitScreen.View;
using AppShellSplitScreen.ViewModel;
using Microsoft.Extensions.Logging;

namespace AppShellSplitScreen
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            // Pages
            builder.Services.AddTransient<NewPage1>();
            builder.Services.AddTransient<NewPage2>();
            builder.Services.AddTransient<NewPage3>();
            builder.Services.AddTransient<StaticPage>();

            // ViewModels
            builder.Services.AddTransient<NewPage1ViewModel>();
            builder.Services.AddTransient<NewPage2ViewModel>();
            builder.Services.AddTransient<NewPage3ViewModel>();
            builder.Services.AddTransient<StaticPageViewModel>();

            // Services
            builder.Services.AddSingleton<IPageService, PageService>();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
