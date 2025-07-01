using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Names.Services.NavigateService;

namespace Names.ViewModels
{
    public partial class OrderListViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        public OrderListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void NavigateToOrderDetail(object param)
        {
            if (param is string str && int.TryParse(str, out int orderId))
            {
                _navigationService.NavigateTo<OrderDetailViewModel>(orderId);
            }
        }
    }
}
