using Microsoft.EntityFrameworkCore;
using LevshinaRecipes.Models;
using System.Collections.Generic;

namespace MyWebApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
