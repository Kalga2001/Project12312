using OnlineShop.API.Middlewares;

namespace OnlineShop.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<ExceptionHandlingMiddleware>();

        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app) => app.UseMiddleware<DbTransactionMiddleware>();
    }
}
