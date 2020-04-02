using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
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
    //usemeuiddleware serve para simplificar a chamada do middleware
    public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder) //this sigifica criar um metodo de extensao dentro da interface
    {
        return builder.UseMiddleware<MeuMiddleware>(); //cria uma entensao para chamar o middlware diretamente, sem ter q adiciona-lo
    }
}