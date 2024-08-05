using AppShellSplitScreen.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppShellSplitScreen.ViewModel
{
    public partial class StaticPageViewModel : ObservableObject
    {
        private readonly IPageService _pageService;

        [ObservableProperty]
        string text = string.Empty;

        public StaticPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            _pageService.StaticMessageUpdated += OnStaticMessageUpdated;
            Text = _pageService.GetStaticMessage();
        }

        private void OnStaticMessageUpdated(object sender, string message)
        {
            Text = message;
        }
    }
}
