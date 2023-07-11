using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web_api.Data;
using web_api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Brain.Data;Trusted_Connection=True;MultipleActiveResultSets=true"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
async Task<List<Meal>> GetMeals(RestaurantContext context) => await context.Meals.ToListAsync();
app.MapGet("/meals/{Id}", async (RestaurantContext context, int Id) =>
{
    var currentMeal = await context.Meals
    .Include(meal => meal.Category)
    .FirstOrDefaultAsync(meal => meal.Id == Id);

    if (currentMeal != null)
    {
        return Results.Ok(currentMeal);
    }
    else
    {
        return Results.NotFound("No Category with this Id");
    }
});
#region POST METHODS
app.MapPost("/meals", async (RestaurantContext context, Meal meal) =>
{
    context.Meals.Add(meal);
    await context.SaveChangesAsync();
    return Results.Ok(await GetMeals(context));
});
#endregion


#region UPDATE METHODS

app.MapPut("/meals/{id}", async (RestaurantContext context, Meal meal, int id) =>
{
    var currentMeal = await context.Meals.FindAsync(id);
    if (currentMeal == null) return Results.NotFound("No Meal found.");

    currentMeal.Name = meal.Name;
    currentMeal.Price = meal.Price;

    await context.SaveChangesAsync();

    return Results.Ok(await GetMeals(context));
});
#endregion

app.MapDelete("/meals/{id}", async (RestaurantContext context, int id) =>
{
    var currentMeal = await context.Meals.FindAsync(id);
    if (currentMeal == null) return Results.NotFound("No Meal found.");

    context.Meals.Remove(currentMeal);
    await context.SaveChangesAsync();

    return Results.Ok();
});
app.Run();