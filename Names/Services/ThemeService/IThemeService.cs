namespace Names.Services.ThemeService;
public interface IThemeService
{
    string? CurrentTheme { get; }
    void ApplyTheme(string theme);
}
