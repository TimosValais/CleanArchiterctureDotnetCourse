// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
using System.Text;
using System.Text.Json;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            var request = httpContext.Request;
            if (request.Method == HttpMethods.Post && request.ContentLength > 0)
            {
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                //get body string here...
                var requestContent = Encoding.UTF8.GetString(buffer);

                request.Body.Position = 0;  //rewinding the stream to 0

                Console.WriteLine(requestContent);

            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"The error is : {ex.Message}");
        }

        await _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggerMiddleware>();
    }
}