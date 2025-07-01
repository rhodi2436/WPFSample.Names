using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Names.Services.NavigateService;
public static class ViewLocator
{
    public static FrameworkElement LocateForViewModel(object viewModel)
    {
        var vmType = viewModel.GetType();
        var viewTypeName = vmType.FullName!.Replace("ViewModel", "View");
        var viewType = Type.GetType(viewTypeName);

        return (FrameworkElement)App.ServiceProvider.GetRequiredService(viewType);
    }
}
