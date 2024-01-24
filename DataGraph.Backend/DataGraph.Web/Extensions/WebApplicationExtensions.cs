using DataGraph.Web.Middleware;

namespace DataGraph.Web.Extensions;

public static class WebApplicationExtensions
{
    public static void UseRequestTimeLogMiddleware(this WebApplication app) 
    {
        app.UseMiddleware<RequestTimeLogMiddleware>();
    }
}
