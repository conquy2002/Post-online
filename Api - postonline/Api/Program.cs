using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Data;
using Api.Models;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddCors( c =>
{
    c.AddPolicy("AllowOrigin",o => o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    o => o.SerializerSettings.ReferenceLoopHandling =  Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
