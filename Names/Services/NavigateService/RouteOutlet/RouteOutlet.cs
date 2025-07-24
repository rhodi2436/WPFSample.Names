using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Names.Services.NavigateService.RouteOutlet;
public class RouteOutlet : ContentControl, IRouteOutlet
{
    private static readonly string DefaultOutletName = "main";

    public static readonly DependencyProperty OutletNameProperty =
        DependencyProperty.Register(nameof(OutletName), typeof(string), typeof(RouteOutlet),
            new FrameworkPropertyMetadata(DefaultOutletName, FrameworkPropertyMetadataOptions.AffectsMeasure));

    public string OutletName
    {
        get => (string)GetValue(OutletNameProperty);
        set => SetValue(OutletNameProperty, value);
    }

    public void SetContent(UIElement view)
    {
        Content = view;
    }

    private static void OnOutletNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is RouteOutlet outlet)
        {
            outlet.TryRegister();
        }
    }

    private bool _isRegistered = false;

    private void TryRegister()
    {
        // 避免设计器出错
        if (DesignerProperties.GetIsInDesignMode(this))
            return;

        if (!_isRegistered)
        {
            _isRegistered = true;
            var navigationService = App.ServiceProvider.GetRequiredService<INavigationService>();
            navigationService.RegisterOutlet(this);
        }
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        TryRegister();
    }
}
