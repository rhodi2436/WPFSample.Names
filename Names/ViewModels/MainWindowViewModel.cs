using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Names.Services.NavigateService;
using Names.Services.ThemeService;

namespace Names.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private INavigationService _navigationService;
        private IThemeService _themeService;

        public MainWindowViewModel(INavigationService navigationService, IThemeService themeService)
        {
            _navigationService = navigationService;
            _themeService = themeService;
        }

        [ObservableProperty]
        private int _number;

        [RelayCommand]
        private void IncreaseNumber()
        {
            Number += 1;
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            _navigationService.NavigateTo<HomeViewModel>("main");
        }

        [RelayCommand]
        private void NavigateToOrderList()
        {
            _navigationService.NavigateTo<OrderListViewModel>("main");
        }

        [RelayCommand]
        private void ToggleTheme()
        {
            var currentTheme = _themeService.CurrentTheme;
            switch (currentTheme)
            {
                case "Light": _themeService.ApplyTheme("Dark"); break;
                case "Dark": _themeService.ApplyTheme("Light"); break;
                default: _themeService.ApplyTheme("Light"); break;
            }
        }
    }
}
