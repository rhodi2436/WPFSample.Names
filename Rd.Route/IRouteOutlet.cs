namespace Rd.Route;
internal interface IRouteOutlet
{
    string Name { get; }
    void SetContent(System.Windows.UIElement view);
}
