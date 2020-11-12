using FuelStation.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Sewing.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
//Компонент middleware, вызываемый в классе Startup, для инициализации базы данных путем заполнения ее таблиц тестовым набором записей.
namespace FuelStation.Middleware
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, SewingContext dbContext)
        {
            if (context.Request.Path.HasValue)
                if (context.Request.Path.Value.ToLower().EndsWith("initialize"))
                    DbInitializer.Initialize(dbContext);


            return _next.Invoke(context);
        }
    }
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }

    }

}
