namespace Names.Services.NavigateService;
public interface INavigationService
{
    void NavigateTo<TViewModel>() where TViewModel : class;

    void NavigateTo<TViewModel>(object navigationParameter) where TViewModel : class, INavigationAware;
}
