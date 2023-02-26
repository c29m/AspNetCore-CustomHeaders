using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Mdameer.AspNetCore.CustomHeaders
{
    internal class ConfigurationCustomHeadersProvider : ICustomHeadersProvider
    {
        private readonly IConfiguration configuration;

        public ConfigurationCustomHeadersProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<KeyValuePair<string, StringValues>> GetCustomHeaders()
        {
            if (!configuration.GetSection("CustomHeaders").Exists())
                yield break;

            foreach (var item in configuration.GetSection("CustomHeaders").GetChildren())
            {
                var values = new List<string>();

                if (item.GetChildren().Any())
                {
                    foreach (var children in item.GetChildren())
                    {
                        values.Add(children.Value);
                    }
                }
                else
                {
                    values.Add(item.Value);
                }

                yield return new KeyValuePair<string, StringValues>(item.Key, new StringValues(values.ToArray()));
            }
        }
    }
}
