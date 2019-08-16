namespace StrumskaSlava.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using StrumskaSlava.Web.Middlewares;

    public static class SeedAdminUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedAdminUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedAdminUserMiddleware>();
        }
    }
}