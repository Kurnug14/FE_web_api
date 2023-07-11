global using Microsoft.EntityFrameworkCore;
using web_api.Model;
namespace web_api.Data
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Category> Categories => Set<Category>();
        
        
    }
}
