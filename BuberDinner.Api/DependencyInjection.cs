using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BuberDinner.Api.Common.Errors;

namespace BuberDinner.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddSingleton<ProblemDetailsFactory, ApiProblemDetailsFactory>();
		services.AddMappings();
		return services;
	}
}