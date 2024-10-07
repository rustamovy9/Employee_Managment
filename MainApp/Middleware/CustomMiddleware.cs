using System.Diagnostics;

namespace MainApp.Middleware;

public class RequestMiddleware
{
    private readonly RequestDelegate _next;
    public RequestMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    private int _requestCount = 0;
    private const int LimitRequest = 10;
    private DateTime _resetTime = DateTime.UtcNow.AddSeconds(5);
    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch watch = Stopwatch.StartNew();
        PathString requestPath = context.Request.Path;
        string requestMethod = context.Request.Method;
       
        if (DateTime.UtcNow > _resetTime)
        {
            _requestCount = 0; 
            _resetTime = DateTime.UtcNow.AddSeconds(10); 
        }
        else
        {
            _requestCount++;
        }

        if (_requestCount > LimitRequest)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;  
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Превышен лимит запросов. Попробуйте позже.");
            return;
        }
        
        Console.WriteLine($"Входящий Запрос: {requestMethod} {requestPath}");
        await _next(context);
        watch.Stop();
        var responseStatusCode = context.Response.StatusCode;
        Console.WriteLine($"Исходящий Ответ: {responseStatusCode} для {requestMethod} {requestPath} - За это время - {watch.ElapsedMilliseconds} ms");
    }
}