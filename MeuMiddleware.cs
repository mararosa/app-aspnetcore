using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class MeuMiddleware
{
    //middleware tem que ter um request delegate
    // um construtor que recebe a injecao de dependecia do request delegate
    // a chamada de um metodo invoke async que retorna uma task, onde recebe um contexto e chama o proximo repassando o contexto. Ou seja repassando o request para o prox. processamento
    private readonly RequestDelegate _next;
    public MeuMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("\n\r ------ Antes ------ \n\r");
        
        await _next(context);

        Console.WriteLine("\n\r ------ Depois ------ \n\r");
    }
}

public static class MeuMiddlewareExtension
{
    
}