using Carter;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Extentions
{
    public static class CarterExtentions
    {
        public static IServiceCollection AddCarterWithAssemplies(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                services.AddCarter(configurator: config =>
                {
                    var catalogModules = assembly.GetTypes()
                        .Where(t => t.IsAssignableTo(typeof(ICarterModule)))
                        .ToArray();

                    config.WithModules(catalogModules);
                });
            }

            return services;
        }
    }
}
