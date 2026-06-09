using CommunityToolkit.Mvvm.ComponentModel;
using FastingFriend.Services.BaseService;

namespace FastingFriend.Features;

public partial class BasePageViewModel : ObservableObject, INavigationAware, IApplicationLifecycleAware, IInitialize, IInitializeAsync
{
    public BasePageViewModel(IBaseService baseService)
    {
        NavigationService = baseService.NavigationService;
    }

    public INavigationService NavigationService { get; set; }
    
    public virtual void Initialize(INavigationParameters parameters)
    {
    }
    
    public virtual Task InitializeAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }
    
    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
        _ = OnNavigatedFromAsync(parameters);
    }
    
    public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }
    
    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
        _ = OnNavigatedToAsync(parameters);
    }
    
    public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }

    public virtual void OnResume()
    {
    }

    public virtual void OnSleep()
    {
    }
}