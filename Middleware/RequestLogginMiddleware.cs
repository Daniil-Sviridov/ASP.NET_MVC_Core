using MVC_study.Models;

namespace MVC_study.Middleware
{
    public class RequestLogginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogginMiddleware> _logger;

        public RequestLogginMiddleware(RequestDelegate next, ILogger<RequestLogginMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IMetrics metrics)
        {
            //System.Web.HttpBrowserCapabilities browser = context.Request.Browser;

            string useragent = context.Request.Headers.UserAgent.ToString().ToLower();
            if (!useragent.Contains("edg"))
            {
                await context.Response.WriteAsync("Sorry");
                return;
            }

            string path = context.Request.Path.ToString().ToLower();
            if (path == "/") metrics.incindex();

            if (path.Contains("privacy")) metrics.incprivacy();

            if (path.Contains("product")) metrics.incproducts();

            if (path.Contains("metric")) metrics.incmetrics();



            await _next(context);
        }

    }
}
