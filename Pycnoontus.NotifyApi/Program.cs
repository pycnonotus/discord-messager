using Pycnonotus.Application;
using Pycnonotus.DiscordBot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDiscordBotConfig>(sp =>
{
	var config = new DiscordBotConfig();
	builder.Configuration.GetSection("DiscordConfig").Bind(config);
	return config;
});
builder.Services.AddSingleton<INotifier, DiscordBot>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
