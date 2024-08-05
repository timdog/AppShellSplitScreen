using AppShellSplitScreen.Services;
using AppShellSplitScreen.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShellSplitScreen.ViewModel
{
    public partial class NewPage2ViewModel : ObservableObject
    {
        private readonly IPageService _pageService;

        [ObservableProperty]
        string text = string.Empty;

        public NewPage2ViewModel(IPageService pageService)
        {
            _pageService = pageService;
            Text = "This is New Page 2";
        }

        [RelayCommand]
        async static Task NavigateToNewPage3()
        {
            await Shell.Current.GoToAsync(nameof(NewPage3));
        }

        [RelayCommand]
        async static Task  NavigateBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void UpdateStaticMessage()
        {
            _pageService.UpdateStaticMessage("Message From New Page 2.");
        }
    }
}
