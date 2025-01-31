using BuberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddApplication();
	builder.Services.AddInfrastructure(builder.Configuration);
	builder.Services.AddControllers();

	builder.Services.AddSingleton<ProblemDetailsFactory, ApiProblemDetailsFactory>();
}

var app = builder.Build();
{
	app.UseHttpsRedirection();
	app.MapControllers();
	app.MapGet("/", () => "Server is Living!");

	app.Run();
}
