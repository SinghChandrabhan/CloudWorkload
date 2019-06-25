using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreapi.CustomMiddleware
{
    public class CustomHeaderMiddleware 
    {
        private readonly RequestDelegate _next;
        public CustomHeaderMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            //var cultureQuery = context.Request.Query["culture"];
            //if (!string.IsNullOrWhiteSpace(cultureQuery))
            //{
            //    var culture = new CultureInfo(cultureQuery);

            //    CultureInfo.CurrentCulture = culture;
            //    CultureInfo.CurrentUICulture = culture;

            //}

            context.Response.Headers["x-preprocessed"] ="PRE_PROCESSED";

            // Call the next delegate/middleware in the pipeline
            await _next(context);

            //will not make any effect:
            //context.Response.Headers["x-postprocessed"] = "POST_PROCESSED";
        }

    }
    public static class CustomHeaderMiddlewareeExtensions
    {
        public static IApplicationBuilder UseCustomHeader(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomHeaderMiddleware>();
        }
    }
}
