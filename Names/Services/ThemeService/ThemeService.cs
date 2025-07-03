using System.Windows;

namespace Names.Services.ThemeService;
public class ThemeService : IThemeService
{
    private const string ThemeFolderPath = "Design/";
    private const string ThemeFileSuffix = ".xaml";

    private string? _currentTheme;

    public string CurrentTheme
    {
        get
        {
            return _currentTheme ?? "Light";
        }
        set
        {
            _currentTheme = value;
        }
    }
    public void ApplyTheme(string themeName)
    {
        var themeSource = new Uri($"pack://application:,,,/{ThemeFolderPath}{themeName}{ThemeFileSuffix}", UriKind.Absolute);

        var newDict = new ResourceDictionary { Source = themeSource };

        var appResources = Application.Current.Resources.MergedDictionaries;

        //// 查找并替换旧主题（我们假设主题始终是 MergedDictionaries[0]）
        //var oldTheme = appResources.FirstOrDefault(d =>
        //    d.Source != null &&
        //    d.Source.OriginalString.Contains($"{ThemeFolderPath}{CurrentTheme}{ThemeFileSuffix}"));

        appResources[0] = newDict;


        CurrentTheme = themeName;
    }
}
