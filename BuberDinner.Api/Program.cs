var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddControllers();
}

var app = builder.Build();
{
	app.UseHttpsRedirection();
	app.MapControllers();
	app.MapGet("/", () => "Server is Living!");

	app.Run();
}
