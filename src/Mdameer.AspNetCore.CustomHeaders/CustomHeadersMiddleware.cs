using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Mdameer.AspNetCore.CustomHeaders
{
    public class CustomHeadersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IOptionsMonitor<CustomHeadersOptions> optionsMonitor;

        public CustomHeadersMiddleware(RequestDelegate next, IOptionsMonitor<CustomHeadersOptions> optionsMonitor)
        {
            this.next = next;
            this.optionsMonitor = optionsMonitor;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var options = optionsMonitor.CurrentValue;

            foreach (var header in options)
                httpContext.Response.Headers.Add(header);

            return next(httpContext);
        }
    }
}
