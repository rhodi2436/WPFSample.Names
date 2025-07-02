using Microsoft.Extensions.DependencyInjection;
using Names.Services.NavigateService.RouteOutlet;

namespace Names.Services.NavigateService;
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;
    private readonly Dictionary<string, IRouteOutlet> _routeOutlets = new();

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void RegisterOutlet(IRouteOutlet outlet)
    {
        _routeOutlets[outlet.OutletName] = outlet;
    }

    public void NavigateTo<TViewModel>(string region, object? parameter) where TViewModel : class
    {
        var vm = _provider.GetService<TViewModel>();
        if (vm is INavigationAware aware)
        {
            aware.OnNavigateTo(parameter);
        }

        var view = ViewLocator.LocateForViewModel(vm);
        view.DataContext = vm;

        if (_routeOutlets.TryGetValue(region, out var routeOutlet))
        {
            routeOutlet.SetContent(view);
        }
    }

    public void NavigateTo<TViewModel>(string region) where TViewModel : class
    {
        this.NavigateTo<TViewModel>(region, null);
    }
}
