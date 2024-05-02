using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.DL.ToolsBLU;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.Utlities.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DecodeTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public DecodeTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var auth = httpContext.Request.Headers.Where(e => e.Key == "Authorization")?.FirstOrDefault();
            if (auth is not null && auth.HasValue && !auth.Value.Value.ToString().IsNullOrEmpty())
            {
                var token = auth.Value.Value.ToString();
                var jwtTokenString = Encoding.UTF8.GetString(Convert.FromBase64String(token.Replace("Bearer ", "").ToString()));
                httpContext.Request.Headers.Remove(auth.Value);
                httpContext.Request.Headers.Add("Authorization", "Bearer " + jwtTokenString);
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DecodeTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseDecodeTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DecodeTokenMiddleware>();
        }
    }
}
