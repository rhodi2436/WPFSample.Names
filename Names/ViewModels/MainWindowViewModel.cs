using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Names.Services.NavigateService;

namespace Names.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private INavigationService _navigationService;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
    }
}
