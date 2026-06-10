namespace FastingFriend.Services;

public class NavigationService : INavigationService
{
    private readonly Prism.Navigation.INavigationService _navigationService;
    public NavigationService(Prism.Navigation.INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Task<INavigationResult> NavigateAsync(string name)
    {
        return NavigateAsync(name, null, false, true);
    }

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters)
    {
        return NavigateAsync(name, parameters, false, true);
    }

    public Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation)
    {
        return NavigateAsync(name, null, useModalNavigation, true);
    }

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters, bool useModalNavigation)
    {
        return NavigateAsync(name, parameters, useModalNavigation, true);
    }

    public Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation, bool animated)
    {
        return NavigateAsync(name, null, useModalNavigation, animated);
    }

    public Task<INavigationResult> NavigateAsync(string name, INavigationParameters? parameters, bool useModalNavigation, bool animated)
    {
        return _navigationService.NavigateAsync(name, parameters);
    }

    public Task<INavigationResult> GoBackAsync()
    {
        return GoBackAsync(null, false, true);
    }

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters)
    {
        return GoBackAsync(parameters, false, true);
    }

    public Task<INavigationResult> GoBackAsync(bool useModalNavigation)
    {
        return GoBackAsync(null, useModalNavigation, true);
    }

    public Task<INavigationResult> GoBackAsync(INavigationParameters parameters, bool useModalNavigation)
    {
        return GoBackAsync(parameters, useModalNavigation, true);
    }

    public Task<INavigationResult> GoBackAsync(bool useModalNavigation, bool animated)
    {
        return GoBackAsync(null, useModalNavigation, animated);
    }

    public Task<INavigationResult> GoBackAsync(INavigationParameters? parameters, bool useModalNavigation, bool animated)
    {
        return _navigationService.GoBackAsync(parameters);
    }
}