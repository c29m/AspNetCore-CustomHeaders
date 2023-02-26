using System.Collections.Generic;
using System.Linq;
using Mdameer.AspNetCore.CustomHeaders;
using Microsoft.Extensions.Options;

namespace Mdameer.AspNetCore.CustomHeaders
{
    internal class CustomHeadersConfigureOptions : IConfigureOptions<CustomHeadersOptions>
    {
        private readonly IEnumerable<ICustomHeadersProvider> providers;

        public CustomHeadersConfigureOptions(IEnumerable<ICustomHeadersProvider> providers)
        {
            this.providers = providers;
        }

        public void Configure(CustomHeadersOptions options)
        {
            foreach (var item in providers.SelectMany(p => p.GetCustomHeaders()))
            {
                options.Add(item.Key, item.Value);
            }
        }
    }
}
