using Microsoft.Extensions.DependencyInjection;
using Names.Views;
using System.Windows.Controls;

namespace Names.Services.NavigateService;
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;
    private readonly MainWindow? _window;

    private ContentControl? Region => _window?.MainRegion;

    public NavigationService(IServiceProvider provider, MainWindow window)
    {
        _provider = provider;
        _window = window ?? throw new ArgumentNullException(nameof(window));
    }

    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        if (Region == null) throw new InvalidOperationException("Navigation region is not set.");
        var vm = _provider.GetRequiredService<TViewModel>();
        var view = ViewLocator.LocateForViewModel(vm); // 你可以通过约定命名来找 View
        view.DataContext = vm;
        Region.Content = view;
    }

    public void NavigateTo<TViewModel>(object navigationParameter) where TViewModel : class, INavigationAware
    {
        if (Region == null) throw new InvalidOperationException("Navigation region is not set.");
        var vm = _provider.GetRequiredService<TViewModel>();
        if (vm is INavigationAware aware)
        {
            aware.OnNavigateTo(navigationParameter);
        }
        var view = ViewLocator.LocateForViewModel(vm); // 你可以通过约定命名来找 View
        view.DataContext = vm;
        Region.Content = view;
    }
}