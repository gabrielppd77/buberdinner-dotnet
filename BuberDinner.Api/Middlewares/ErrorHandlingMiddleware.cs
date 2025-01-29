using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middlewares;

public class ErrorHandlingMiddleware
{
	private readonly RequestDelegate _next;

	public ErrorHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var code = HttpStatusCode.InternalServerError;
		var result = JsonSerializer.Serialize(new { error = "An error ocurred while processing your request." });
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)code;
		await context.Response.WriteAsync(result);
	}
}