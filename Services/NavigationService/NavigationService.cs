namespace FastingFriend.Services;

public class NavigationService : INavigationService
{
    private readonly Prism.Navigation.INavigationService _navigationService;
    public NavigationService(Prism.Navigation.INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Task<INavigationResult> NavigateAsync(string name)
        => NavigateAsync(name, null, false, true);

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters)
        => NavigateAsync(name, parameters, false, true);

    public Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation)
        => NavigateAsync(name, null, useModalNavigation, true);

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters, bool useModalNavigation)
        => NavigateAsync(name, parameters, useModalNavigation, true);

    public Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation, bool animated)
        => NavigateAsync(name, null, useModalNavigation, animated);

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters, bool useModalNavigation, bool animated)
    {
        return _navigationService.NavigateAsync(name, parameters);
    }

    public Task<INavigationResult> GoBackAsync()
        => GoBackAsync(null, false, true);

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters)
        => GoBackAsync(parameters, false, true);

    public Task<INavigationResult> GoBackAsync(bool useModalNavigation)
        => GoBackAsync(null, useModalNavigation, true);

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters, bool useModalNavigation)
        => GoBackAsync(parameters, useModalNavigation, true);

    public Task<INavigationResult> GoBackAsync(bool useModalNavigation, bool animated)
        => GoBackAsync(null, useModalNavigation, animated);

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters, bool useModalNavigation, bool animated)
    {
        return _navigationService.GoBackAsync(parameters);
    }
}