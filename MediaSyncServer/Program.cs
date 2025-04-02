using MediaSyncServer.DependencyInjection;
using MediaSyncServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Localhost",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5500");
                          policy.AllowAnyHeader();
                          policy.AllowCredentials();
                      });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.RegisterServices(builder.Environment, builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("Localhost");

app.MapControllers();
app.MapHub<MediaControlsHub>("/mediacontrols");

app.Run();
