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

        public async Task InvokeAsync(HttpContext context)
        {
            //System.Web.HttpBrowserCapabilities browser = context.Request.Browser;

            string useragent = context.Request.Headers.UserAgent.ToString();
            if (!useragent.ToLower().Contains("edg")) 
            {
                await context.Response.WriteAsync("Sorry");
                return ;
            }

            await _next(context);
        }

    }
}
