using System.Reflection;

namespace FastingFriend;

public static class RegistrationController
{
    private const string ViewModel = "ViewModel";
    private const string Page = "Page";
    private const string Service = "Service";
    
    public static void RegisterPages(IContainerRegistry serviceCollection)
    {
        // Automatically register Pages and their corresponding ViewModels for navigation.
        // A page named MyPage is paired with a ViewModel named MyPageViewModel.
        var pageTypes = GetTypes(x => x.EndsWith(Page));

        foreach (var pageType in pageTypes)
        {
            var viewModelName = pageType.Name + ViewModel;
            var viewModelType = GetTypes(x => x.Equals(viewModelName)).FirstOrDefault();
            
            // Only register for navigation if we can find a matching ViewModel
            if (viewModelType is not null)
            {
                serviceCollection.RegisterForNavigation(pageType, viewModelType);
            }
        }
    }

    public static void RegisterServices(IContainerRegistry services)
    {
        var serviceTypes = GetTypes(className => className.EndsWith(Service));
        foreach (var type in serviceTypes)
        {
            
            var interfaces = type.GetInterfaces();
            
            // Do not perform any registration if the service does not have any interfaces
            if (interfaces.Length == 0)
            {
                break;
            }

            PerformServiceRegistration(services, interfaces, type);
        }
    }

    private static void PerformServiceRegistration(
        IContainerRegistry services, 
        Type[] interfaces,
        Type serviceBaseType)
    {
        var shouldRegisterAsSingleton = ShouldRegisterAsSingleton(serviceBaseType);
        
        // If a service implements multiple interfaces, register each interface separately
        foreach (var serviceInterface in interfaces)
        {
            if (shouldRegisterAsSingleton)
            {
                services.RegisterSingleton(serviceInterface, serviceBaseType);
            }
            else
            {
                services.Register(serviceInterface, serviceBaseType);
            }
        }
    }

    /// <summary>
    /// Returns a list of Type that are <c>Class</c> objects and are not <c>Abstract</c>. 
    /// </summary>
    /// <param name="nameCheck">Additional filtering for returned results.</param>
    /// <returns>List of Type</returns>
    private static List<Type> GetTypes(Func<string, bool> nameCheck)
    {
        return typeof(AppInitialisation).Assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false } && nameCheck.Invoke(type.Name)).ToList();
    }

    private static bool ShouldRegisterAsSingleton(Type serviceType)
    {
        var serviceRegistrationAttribute = serviceType.GetCustomAttributes<BaseServiceRegistrationAttribute>().FirstOrDefault();
        return serviceRegistrationAttribute is SingletonService;
    }
}