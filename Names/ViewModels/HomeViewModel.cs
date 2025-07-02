using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Names.Services.NavigateService;

namespace Names.ViewModels;
public partial class HomeViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;

    public HomeViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }



    [RelayCommand]
    void NavigateToOrderList()
    {
        _navigationService.NavigateTo<OrderListViewModel>("main");
    }

    public void OnNavigateTo(object? navigationParameter)
    {
        // TODO 处理路由参数
        if (navigationParameter == null) { return; }
        return;
    }
}
