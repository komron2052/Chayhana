using Chayhana.Service.Exeptions;

namespace Chayhana.API.Middlewares;

public class ExeptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExeptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (CustomExeption exeption)
        {
            context.Response.StatusCode = exeption.Code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = exeption.Code,
                Error = exeption.Message
            });
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = 500,
                Error = exception.Message
            });
        }
    }
}
