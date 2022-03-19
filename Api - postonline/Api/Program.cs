using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Data;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/user", async (ApiContext db) =>
    await db.User.ToListAsync());

app.MapGet("/user/{id}", async (int id, ApiContext db) =>
    await db.User.FindAsync(id)
        is User user
            ? Results.Ok(user)
            : Results.NotFound());

app.MapPost("/user", async (User user, ApiContext db) =>
{
    db.User.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/user/{user.Id}", user);
});

app.MapPut("/user/{id}", async (int id, User inputuser, ApiContext db) =>
{
    var user = await db.User.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Name = inputuser.Name;
    user.Email = inputuser.Email;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/user/{id}", async (int id, ApiContext db) =>
{
    if (await db.User.FindAsync(id) is User user)
    {
        db.User.Remove(user);
        await db.SaveChangesAsync();
        return Results.Ok(user);
    }

    return Results.NotFound();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
