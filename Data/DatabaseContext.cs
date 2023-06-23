using CandyShop.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Sweetness> Sweets { get; set; }
        public DbSet<KitContent> KitContent { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<KitsOnly> KitsOnly { get; set; }
        public DbSet<SweetsOnly> SweetsOnly { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
