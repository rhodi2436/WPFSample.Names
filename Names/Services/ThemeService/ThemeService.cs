using System.Windows;

namespace Names.Services.ThemeService;
public class ThemeService : IThemeService
{
    private const string ThemeFolderPath = "Design/";
    private const string ThemeFileSuffix = ".xaml";

    public string? CurrentTheme { get; private set; }

    public void ApplyTheme(string themeName)
    {
        var themeSource = new Uri($"pack://application:,,,/{ThemeFolderPath}{themeName}{ThemeFileSuffix}", UriKind.Absolute);

        var newDict = new ResourceDictionary { Source = themeSource };

        var appResources = Application.Current.Resources.MergedDictionaries;

        // 查找并替换旧主题（我们假设主题始终是 MergedDictionaries[0]）
        var oldTheme = appResources.FirstOrDefault(d =>
            d.Source != null &&
            d.Source.OriginalString.StartsWith($"pack://application:,,,/{ThemeFolderPath}", StringComparison.OrdinalIgnoreCase));

        if (oldTheme != null)
        {
            var index = appResources.IndexOf(oldTheme);
            appResources[index] = newDict;
        }
        else
        {
            appResources.Insert(0, newDict);
        }

        CurrentTheme = themeName;
    }
}
