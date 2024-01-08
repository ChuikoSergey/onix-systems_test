using System.Diagnostics;

namespace DataGraph.Web.Middleware;

public class RequestTimeLogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimeLogMiddleware> _logger;

    public RequestTimeLogMiddleware(RequestDelegate next, ILogger<RequestTimeLogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        _logger.LogInformation($"Start of Action: {context.Request.Path} at {DateTime.UtcNow}");

        await _next(context);

        stopwatch.Stop();
        _logger.LogInformation($"End of Action: {context.Request.Path} at {DateTime.UtcNow}. Duration: {stopwatch.ElapsedMilliseconds}ms");
    }

}
