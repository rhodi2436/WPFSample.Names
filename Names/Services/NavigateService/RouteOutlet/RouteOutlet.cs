using System.Windows;
using System.Windows.Controls;

namespace Names.Services.NavigateService.RouteOutlet;
public class RouteOutlet : ContentControl, IRouteOutlet
{
    public string OutletName { get; set; } = "main";

    public void SetContent(UIElement view)
    {
        Content = view;
    }
}
