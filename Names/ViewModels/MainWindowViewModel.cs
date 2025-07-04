using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Names.Services.NavigateService;
using Names.Services.ThemeService;
using Names.Utils;
using System.Windows;
using System.Windows.Controls;

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
            var toTheme = currentTheme switch
            {
                "Light" => "Dark",
                "Dark" => "Light",
                _ => "Dark",
            };
            var target = App.Current.MainWindow.Content;
            VisualTransitionPlayer.Play(new VisualTransitionPlayer.TransitionOptions
            {
                VisualTarget = target as FrameworkElement,
                OverlayHost = target as Panel,
                Duration = TimeSpan.FromMilliseconds(600),
                BeforeAnimation = () =>
                {
                    _themeService.ApplyTheme(toTheme);
                }
            });
        }
    }
}
