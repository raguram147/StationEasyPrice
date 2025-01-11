using System.Reflection;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// Registers all services that follow the 'Service' suffix convention.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the services to.</param>
    /// <param name="assembly">The assembly that contains the service classes to register.</param>
    public static void AddServices(this IServiceCollection services, Assembly assembly)
    {
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Service") && t.IsClass && !t.IsAbstract);

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterface($"I{serviceType.Name}");

            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, serviceType);
            }
        }
    }
}
