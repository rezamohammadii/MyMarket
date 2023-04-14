using StoneMarket.AccessLayer.Context;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace StoneMarket.Utils
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AuthMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<AuthMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context, StoneMarketContext db)
        {
            var regex = new Regex(@"\/admin\/([^\/\s]*)(?:.*)");
            var match = regex.Match(context.Request.Path);
            if (match.Success && !string.IsNullOrEmpty(match.Groups[1].Value))
            {
                if (context.User.Identity != null)
                {
                    if (context.User.Identity.IsAuthenticated)
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.Redirect("/admin/login");
                        return;
                    }
                }
                else
                {
                    context.Response.Redirect("/admin/login");
                    return;
                }
                //context.Items["domain"] = domain_;
            }
            await _next(context);

        }
    }

}
