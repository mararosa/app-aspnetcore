using Microsoft.AspNetCore.Http;

public class MeuMiddleware
{
    private readonly RequestDelegate _next;
    public MeuMiddleware(RequestDelegate next)
    {
        _next = next;
    }
}