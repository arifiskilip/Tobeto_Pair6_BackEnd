using Core.CrossCuttingConcers.ExceptionsV2.Type;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcers.ExceptionsV2;

public class ExceptionMiddlewareV2
{
	private readonly RequestDelegate _next;

	public ExceptionMiddlewareV2(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (IException exception)
		{
			await HandleException(exception, context);
		}

	}
	private async Task HandleException(IException exception, HttpContext context)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = exception.StatusCode;
		exception.Detail = exception.Detail;
		await context.Response.WriteAsync(JsonSerializer.Serialize(new HttpMessage()
		{
			Detail = exception.Detail,
			StatusCode = exception.StatusCode,
			Title = exception.Title,
			Type = exception.GetType().Name
		}));
	}
}


 class HttpMessage
{
	public int StatusCode { get; set; }
	public string Title { get; set; }
	public string Detail { get; set; }
	public string Type { get; set; }
}
