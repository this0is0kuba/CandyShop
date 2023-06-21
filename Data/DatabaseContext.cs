using CandyShop.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sweetness> Sweets { get; set; }
        public DbSet<KitContent> KitContents { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<KitsOnly> KitsOnlies { get; set; }
        public DbSet<SweetsOnly> SweetsOnly { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
