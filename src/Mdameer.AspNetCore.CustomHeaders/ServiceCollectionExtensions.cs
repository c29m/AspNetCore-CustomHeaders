using System;
using Mdameer.AspNetCore.CustomHeaders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Mdameer.AspNetCore.CustomHeaders
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomHeaders(this IServiceCollection services)
        {
            return services.AddCustomHeaders(options => { });
        }

        public static IServiceCollection AddCustomHeaders(this IServiceCollection services, Action<CustomHeadersOptions> configure)
        {
            services.TryAddSingleton<CustomHeadersMarkerService>();

            services.TryAddEnumerable(ServiceDescriptor.Transient<ICustomHeadersProvider, ConfigurationCustomHeadersProvider>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<CustomHeadersOptions>, CustomHeadersConfigureOptions>());

            services.Configure(configure);

            return services;
        }
    }
}
