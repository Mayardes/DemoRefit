using DemoRefit.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = string.Empty;
var refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = (rt, rq) => Task.FromResult(authToken),
};

//Notice that we are passing refitsettings parameter to AddRefitClient
//AddRefitClient is on package Refit.HttpClientFactory

builder.Services.AddRefitClient<ITmdbApi>(refitSettings).ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));

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
