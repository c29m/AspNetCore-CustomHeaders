using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Mdameer.AspNetCore.CustomHeaders
{
    public interface ICustomHeadersProvider
    {
        public IEnumerable<KeyValuePair<string, StringValues>> GetCustomHeaders();
    }
}
