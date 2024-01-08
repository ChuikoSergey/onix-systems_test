using DataGraph.Web.Middleware;
using Microsoft.EntityFrameworkCore;

namespace DataGraph.Web.Extensions;

public static class WebApplicationExtensions
{
    public static void MigrateDbContext<TContext>(this WebApplication app) where TContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<TContext>();
        if (context != null)
        {
            context.Database.Migrate();
        }
    }

    public static void UseRequestTimeLogMiddleware(this WebApplication app) 
    {
        app.UseMiddleware<RequestTimeLogMiddleware>();
    }
}
