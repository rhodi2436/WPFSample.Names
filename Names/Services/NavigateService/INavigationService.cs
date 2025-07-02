using Names.Services.NavigateService.RouteOutlet;

namespace Names.Services.NavigateService;
public interface INavigationService
{
    void RegisterOutlet(IRouteOutlet outlet);
    void NavigateTo<TViewModel>(string region) where TViewModel : class;
    void NavigateTo<TViewModel>(string region, object? parameter) where TViewModel : class;
}
