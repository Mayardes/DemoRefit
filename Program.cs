using DemoRefit.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmYzI5YzNhYmY0MmM0MTAzNjExMDliOGZkNjg2YjhlYiIsInN1YiI6IjY2NjEwMDI2OGZkYzZkMzc0YmI3NWEwYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.flsU59Y_xIO-Zg3h766s0JrHQfiuFU7KcnmAuA3lc5M";
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
