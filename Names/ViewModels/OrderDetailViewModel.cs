using CommunityToolkit.Mvvm.ComponentModel;
using Names.Services.NavigateService;

namespace Names.ViewModels
{
    public partial class OrderDetailViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        public OrderDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [ObservableProperty]
        private int _orderId;

        public void OnNavigateTo(object? navigationParameter)
        {
            ArgumentNullException.ThrowIfNull(nameof(navigationParameter));

            if (navigationParameter is int id)
            {
                OrderId = id;
            }
        }
    }
}
