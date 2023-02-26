using Microsoft.Extensions.Primitives;

namespace Mdameer.AspNetCore.CustomHeaders.Web
{
    public class CustomHeadersProvider : ICustomHeadersProvider
    {
        public IEnumerable<KeyValuePair<string, StringValues>> GetCustomHeaders()
        {
            yield return new KeyValuePair<string, StringValues>("X-CustomHeader-Provider", "Sample Value");
        }
    }
}
