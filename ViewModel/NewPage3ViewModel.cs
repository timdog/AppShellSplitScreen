using AppShellSplitScreen.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShellSplitScreen.ViewModel
{
    public partial class NewPage3ViewModel : ObservableObject
    {
        private readonly IPageService _pageService;

        [ObservableProperty]
        string text = string.Empty;

        public NewPage3ViewModel(IPageService pageService)
        {
            _pageService = pageService;
            Text = "This is New Page 3";
        }

        [RelayCommand]
        async static Task NavigateBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void UpdateStaticMessage()
        {
            _pageService.UpdateStaticMessage("Message From New Page 3.");
        }
    }
}
