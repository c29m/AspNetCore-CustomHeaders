using System;
using Mdameer.AspNetCore.CustomHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Mdameer.AspNetCore.CustomHeaders
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomHeaders(this IApplicationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (builder.ApplicationServices.GetService<CustomHeadersMarkerService>() == null)
            {
                throw new InvalidOperationException("Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddCustomHeaders' inside the call to 'ConfigureServices(...)' in the application startup code.");
            }

            return builder.UseMiddleware<CustomHeadersMiddleware>();
        }
    }
}
