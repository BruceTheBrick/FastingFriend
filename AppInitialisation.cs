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
        builder.CreateWindow($"{Routes.NavigationPage}/{Routes.MainPage}");
        builder.RegisterTypes(RegisterServices);
    }

    private static void RegisterServices(IContainerRegistry serviceCollection)
    {
        // Automatically register all concrete types ending with 'Service'
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var serviceTypes = assemblies
            .SelectMany(a => a.GetTypes().Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("Service")))
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
}