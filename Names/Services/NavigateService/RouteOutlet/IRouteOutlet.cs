using System.Windows;

namespace Names.Services.NavigateService.RouteOutlet;
public interface IRouteOutlet
{
    string OutletName { get; }
    void SetContent(UIElement view);
}
