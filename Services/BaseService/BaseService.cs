namespace FastingFriend.Services.BaseService;

public class BaseService : IBaseService
{
    public BaseService(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public INavigationService NavigationService { get; }
}