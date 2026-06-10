namespace FastingFriend;

public static class AppInitialisation
{
    

    public static MauiAppBuilder UseAppInitialiser(this MauiAppBuilder builder)
    {
        builder.UsePrism(ConfigurePrism);
        return builder;
    }

    private static void ConfigurePrism(PrismAppBuilder builder)
    {
        builder.CreateWindow($"{Routes.NavigationPage}/{Routes.DashboardPage}");
        builder.RegisterTypes(RegisterTypes);
    }

    private static void RegisterTypes(IContainerRegistry serviceCollection)
    {
        RegisterServices(serviceCollection);
        RegistrationController.RegisterPages(serviceCollection);
    }


    private static void RegisterServices(IContainerRegistry services)
    {
        services.RegisterSingleton<Prism.Navigation.INavigationService, Prism.Navigation.PageNavigationService>();
        services.RegisterSingleton<IPreferences>(() => Preferences.Default);
        
        RegistrationController.RegisterServices(services);
    }
}