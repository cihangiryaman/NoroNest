using NoroNest.Application;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.WriteTo.Logger(lc => lc
		.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
		.WriteTo.File(
			path: "Logs/info/info-.txt",
			rollingInterval: RollingInterval.Day,
			outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
			retainedFileCountLimit: 7))
	.WriteTo.Logger(lc => lc
		.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error || e.Level == LogEventLevel.Fatal)
		.WriteTo.File(
			path: "Logs/errors/error-.txt",
			rollingInterval: RollingInterval.Day,
			outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
			retainedFileCountLimit: 30))
	.WriteTo.Console()
	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterNoroNest(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
