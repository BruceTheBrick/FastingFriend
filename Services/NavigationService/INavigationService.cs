namespace FastingFriend.Services;

public interface INavigationService
{
    // Navigate by name
    Task<INavigationResult> NavigateAsync(string name);
    Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters);
    Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation);
    Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters, bool useModalNavigation);
    Task<INavigationResult> NavigateAsync(string name, bool useModalNavigation, bool animated);
    Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters, bool useModalNavigation, bool animated);

    // Go back
    Task<INavigationResult> GoBackAsync();
    Task<INavigationResult> GoBackAsync(INavigationParameters parameters);
    Task<INavigationResult> GoBackAsync(bool useModalNavigation);
    Task<INavigationResult> GoBackAsync(INavigationParameters parameters, bool useModalNavigation);
    Task<INavigationResult> GoBackAsync(bool useModalNavigation, bool animated);
    Task<INavigationResult> GoBackAsync(INavigationParameters parameters, bool useModalNavigation, bool animated);
}