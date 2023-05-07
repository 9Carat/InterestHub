using InterestHub2.Models;
using InterestHub2.Models.DTO;
using InterestHub2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Asp.Net Core Swagger API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(swaggerUiOptions =>
{
    swaggerUiOptions.DocumentTitle = "InterestHub API";
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "An API with the potential to change the world.");
    swaggerUiOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

// API begins here

// GET User
app.MapGet("/getAllUsers", async () => await UserRepository.GetUsersAsync())
    .WithTags("User endpoint");

// GET Link
app.MapGet("/getAllLinks", async () => await LinkRepository.GetLinksAsync())
    .WithTags("Link endpoint");

// GET Interest
app.MapGet("/getAllInterests", async () => await InterestRepository.GetInterestsAsync())
    .WithTags("Interest endpoint");

// GET User/1
app.MapGet(pattern: "/getUser/{userId}", handler: async (int userId) =>
{
    User user = await UserRepository.GetUserByIdAsync(userId);
    if (user != null)
    {
        return Results.Ok(value: user);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User endpoint");

//GET UserInterest
app.MapGet(pattern: "/getUserInterest/{userId}", handler: async (int userId) =>
{
    List<UserInterestDTO> user = await UserRepository.GetUserAndInterestByIdAsync(userId);
    if (user != null)
    {
        return Results.Ok(value: user);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User-Interest endpoint");

// GET UserLink
app.MapGet(pattern: "/getUserLink/{userId}", handler: async (int userId) =>
{
    List<UserLinkDTO> user = await UserRepository.GetUserAndLinkByIdAsync(userId);
    if (user != null)
    {
        return Results.Ok(value: user);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User-Link endpoint");

// POST UserInterest
app.MapPost(pattern: "/connectUserInterest", handler: async (UserInterest userInterest) =>
{
    bool success = await UserRepository.ConnectUserAndInterestAsync(userInterest);
    if (success)
    {
        return Results.Ok(value: "User successfully connected to interest");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User-Interest endpoint");

// POST UserLink
app.MapPost(pattern: "/postLink", handler: async (Link link) =>
{
    bool success = await LinkRepository.AddLinkAsync(link);
    if (success)
    {
        return Results.Ok(value: "Link was successfully posted");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Link endpoint");

// POST UserInterestLink
app.MapPost(pattern: "/connectUserLink", handler: async (UserInterestLink uil) =>
{
    bool success = await UserRepository.ConnectUserLinkAsync(uil);
    if (success)
    {
        return Results.Ok(value: "Link was successfully connected to user");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User-Link endpoint");


app.Run();
