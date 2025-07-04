using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Names.Utils;
public static class VisualTransitionPlayer
{
    public class TransitionOptions
    {
        public FrameworkElement VisualTarget { get; set; } = null!;
        public Panel OverlayHost { get; set; } = null!;
        public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(500);
        public Action? BeforeAnimation { get; set; }
        public Action? AfterAnimation { get; set; }
        public Action<Image>? CustomizeImage { get; set; }  // 可设置 Blur、Transform 等
    }

    public static void Play(TransitionOptions options)
    {
        if (options.VisualTarget == null || options.OverlayHost == null)
            throw new ArgumentNullException("Missing VisualTarget or OverlayHost");

        var dpi = VisualTreeHelper.GetDpi(options.VisualTarget);
        var width = (int)(options.VisualTarget.ActualWidth * dpi.DpiScaleX);
        var height = (int)(options.VisualTarget.ActualHeight * dpi.DpiScaleY);

        var rtb = new RenderTargetBitmap(width, height, dpi.PixelsPerInchX, dpi.PixelsPerInchY, PixelFormats.Pbgra32);
        rtb.Render(options.VisualTarget);

        var image = new Image
        {
            Source = rtb,
            Stretch = Stretch.Fill,
            SnapsToDevicePixels = true,
            UseLayoutRounding = true
        };

        options.CustomizeImage?.Invoke(image); // 可设置效果，比如模糊或缩放

        var overlay = new Grid
        {
            Background = Brushes.Transparent
        };
        overlay.Children.Add(image);

        Panel.SetZIndex(overlay, int.MaxValue);
        options.OverlayHost.Children.Add(overlay);

        options.BeforeAnimation?.Invoke();

        var fadeAnim = new DoubleAnimation(1.0, 0.0, options.Duration);
        fadeAnim.Completed += (s, e) =>
        {
            options.OverlayHost.Children.Remove(overlay);
            options.AfterAnimation?.Invoke();
        };

        overlay.BeginAnimation(UIElement.OpacityProperty, fadeAnim);
    }
}
