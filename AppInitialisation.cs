namespace FastingFriend;

public static class AppInitialisation
{
    private const string ViewModel = "ViewModel";
    private const string Page = "Page";
    
    public static MauiAppBuilder UseAppInitialiser(this MauiAppBuilder builder)
    {
        builder.UsePrism(ConfigurePrism);
        return builder;
    }
    
    private static void ConfigurePrism(PrismAppBuilder builder)
    {
        builder.CreateWindow($"{Routes.NavigationPage}/{Routes.MainPage}");
        builder.RegisterTypes(RegisterTypes);
    }

    private static void RegisterTypes(IContainerRegistry serviceCollection)
    {
        RegisterServices(serviceCollection);
        RegisterPages(serviceCollection);
    }

    private static void RegisterPages(IContainerRegistry serviceCollection)
    {
        // Automatically register Pages and their corresponding ViewModels for navigation.
        // A page named MyPage is paired with a ViewModel named MyPageViewModel.
        var pageTypes = GetTypes(x => x.EndsWith(Page));

        foreach (var page in pageTypes)
        {
            try
            {
                var vmName = page.Name + ViewModel;
                var vmType = GetTypes(x => x.Equals(vmName)).FirstOrDefault();
                if (vmType != null)
                {
                    // Register the page for navigation with its ViewModel
                    // Use the RegisterForNavigation(Type view, Type viewModel) overload if available
                    serviceCollection.RegisterForNavigation(page, vmType);
                }
            }
            catch (Exception ex)
            {
                
            }
    }
    }

    private static void RegisterServices(IContainerRegistry serviceCollection)
    {
        // Automatically register all concrete types ending with 'Service' defined in this assembly only
        var assembly = typeof(AppInitialisation).Assembly;
        var serviceTypes = assembly
            .GetTypes().Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("Service"))
            .ToList();
        foreach (var type in serviceTypes)
        {
            var interfaces = type.GetInterfaces();
            if (interfaces.Length > 0)
            {
                // register for each implemented interface
                foreach (var iface in interfaces)
                    serviceCollection.RegisterSingleton(iface, type);
            }
            else
            {
                // register the concrete type itself
                serviceCollection.RegisterSingleton(type);
            }
        }
    }
    
    private static List<Type> GetTypes(Func<string, bool> nameCheck)
    {
        return typeof(AppInitialisation).Assembly.GetTypes().Where(type => type is { IsClass: true, IsAbstract: false } && nameCheck.Invoke(type.Name)).ToList();
    }
}