namespace FastingFriend.Features;

public class BasePageViewModel
{
    public BasePageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public INavigationService NavigationService { get; set; }
}