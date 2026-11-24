using Microsoft.EntityFrameworkCore;
using SwimSchool.Api;
using SwimSchool.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SwimSchool")
    ?? throw new InvalidOperationException("The SwimSchool connection string is missing.");

builder.Services.AddDbContext<SwimSchoolDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/health", async (SwimSchoolDbContext dbContext, CancellationToken cancellationToken) =>
{
    await dbContext.Database.OpenConnectionAsync(cancellationToken);
    await dbContext.Database.CloseConnectionAsync();

    return TypedResults.Ok(new { status = "ok", database = "sqlite" });
});

app.MapGet("/classes", GetClassesAsync);

app.Run();

static Task<IReadOnlyList<SwimClassResponse>> GetClassesAsync(
    bool? hasSpots,
    SwimSchoolDbContext dbContext,
    CancellationToken cancellationToken)
{
    // TODO: Build the LINQ query and project results to SwimClassResponse.
    throw new NotImplementedException("The class query has not been implemented yet.");
}
