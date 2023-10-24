using System.Text.Json.Serialization;
using BE_charity_direct.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using BE_charity_direct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<CharityDirectoryDbContext>(builder.Configuration["CharityDirectoryDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7287")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Users

//Create User
app.MapPost("/register", (CharityDirectoryDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

app.MapGet("/checkuser/{uid}", (CharityDirectoryDbContext db, string uid) =>
{
    var user = db.Users.Where(x => x.uid == uid).ToList();
    if (uid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(user);
    }
});

app.MapGet("/user", (CharityDirectoryDbContext db) =>
{
    return db.Users.ToList();
});

app.MapGet("/user/{id}", (CharityDirectoryDbContext db, int id) =>
{
    var user = db.Users.Where(u => u.Id == id);
    return user;
});

// Charities 

app.MapGet("/charity", (CharityDirectoryDbContext db) =>
{
    return db.Charities.ToList();
});

app.MapGet("/charity/{id}", (CharityDirectoryDbContext db, int id) =>
{
    var charities = db.Charities.SingleOrDefaultAsync(u => u.Id == id);
    return charities;
});

app.MapPost("/charity", (CharityDirectoryDbContext db, Charity charity) =>
{
    db.Charities.Add(charity);
    db.SaveChanges();
    return Results.Created($"/api/charity/{charity.Id}", charity);
});

app.MapPut("/charity/{id}", (CharityDirectoryDbContext db, int id, Charity charity) =>
{
    Charity charityToUpdate = db.Charities.FirstOrDefault(c => c.Id == id);
    if (charityToUpdate == null)
    {
        return Results.NotFound();
    }
    charityToUpdate.Name = charity.Name;
    charityToUpdate.Description = charity.Description;
    charityToUpdate.Id = charity.Id;
    charityToUpdate.imgUrl = charity.imgUrl;
    
    db.SaveChanges();
    return Results.Ok(charity);
});

app.MapDelete("/charitiesbyID/{id}", (CharityDirectoryDbContext db, int id) =>
{
    Charity charity = db.Charities.SingleOrDefault(charity => charity.Id == id);
    if (charity == null)
    {
        return Results.NotFound();
    }
    db.Charities.Remove(charity);
    db.SaveChanges();
    return Results.NoContent();

});

// Subscriptions

app.MapDelete("/subscriptionsbyID/{id}", (CharityDirectoryDbContext db, int id) =>
{
    Subscription subscription = db.Subscriptions.SingleOrDefault(subscription => subscription.Id == id);
    if (subscription == null)
    {
        return Results.NotFound();
    }
    db.Subscriptions.Remove(subscription);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapGet("/subscription", (CharityDirectoryDbContext db) =>
{
    return db.Subscriptions.ToList();
});

app.MapPost("/subscription", (CharityDirectoryDbContext db, Subscription subscription) =>
{
    db.Subscriptions.Add(subscription);
    db.SaveChanges();
    return Results.Created($"/subscription/{subscription.Id}", subscription);
});

app.MapGet("/subscriptionsByCharity/{charityId}", (CharityDirectoryDbContext db, int charityId) =>
{
    var users = db.Users
    .Where(u => u.Subscriptions.Any(sub => sub.charityId == charityId)).ToList();

    return users;
});

app.Run();
