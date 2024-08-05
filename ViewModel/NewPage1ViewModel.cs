using AppShellSplitScreen.Services;
using AppShellSplitScreen.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShellSplitScreen.ViewModel
{
    public partial class NewPage1ViewModel : ObservableObject
    {
        private readonly IPageService _pageService;

        [ObservableProperty]
        string text = string.Empty;

        public NewPage1ViewModel(IPageService pageService)
        {
            _pageService = pageService;
            Text = "This is New Page 1";
        }

        [RelayCommand]
        async static Task NavigateToNewPage2()
        {
            await Shell.Current.GoToAsync(nameof(NewPage2));
        }

        [RelayCommand]
        void UpdateStaticMessage()
        {
            _pageService.UpdateStaticMessage("Message From New Page 1.");
        }
    }
}
