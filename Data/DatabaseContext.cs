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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Kit>().HasData(

                new Kit
                {
                    ID = 1,
                    Name = "Lollipop Box",
                    Description = "Wonderful box of lollipops.",
                    CurrentPrice = 10,
                    StockLevel = 80,
                    Discount = 0
                },

                new Kit
                {
                    ID = 2,
                    Name = "Gummy Candy Box",
                    Description = "Wonderful box of gummy candies.",
                    CurrentPrice = 15,
                    StockLevel = 4,
                    Discount = 0
                }

            );

            modelBuilder.Entity<Sweetness>().HasData(

                new Sweetness
                {
                    ID = 1,
                    Name = "Strawberry Lollipop",
                    Description = "Lollipop with an amazing strawberry flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 2,
                    StockLevel = 100,
                    Discount = 0,
                    CategoryName = CategoryName.Lollipops
                },
                
                new Sweetness
                {
                    ID = 2,
                    Name = "Smurf Lollipop",
                    Description = "Lollipop with an amazing smurf flavor.",
                    IsVegan = false,
                    IsGluten = true,
                    CurrentPrice = 3,
                    StockLevel = 600,
                    Discount = 0,
                    CategoryName = CategoryName.Lollipops
                },

                new Sweetness
                {
                    ID = 3,
                    Name = "Orange Lollipop",
                    Description = "Lollipop with an amazing orange flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 2,
                    StockLevel = 100,
                    Discount = 0,
                    CategoryName = CategoryName.Lollipops
                },

                new Sweetness
                {
                    ID = 4,
                    Name = "Watermelon Lollipop",
                    Description = "Lollipop with an amazing watermelon flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 2,
                    StockLevel = 100,
                    Discount = 0,
                    CategoryName = CategoryName.Lollipops
                },

                new Sweetness
                {
                    ID = 5,
                    Name = "BubbleGum Lollipop",
                    Description = "Lollipop with an amazing bubblegum flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 3,
                    StockLevel = 600,
                    Discount = 0,
                    CategoryName = CategoryName.Lollipops
                },

                new Sweetness
                {
                    ID = 6,
                    Name = "BubbleGum Gummy Candy",
                    Description = "Gummy candy with an amazing bubblegum flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 1000,
                    Discount = 0,
                    CategoryName = CategoryName.GummyCandies
                },

                new Sweetness
                {
                    ID = 7,
                    Name = "Orange Gummy Candy",
                    Description = "Gummy candy with an amazing orange flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 2000,
                    Discount = 0,
                    CategoryName = CategoryName.GummyCandies
                },

                new Sweetness
                {
                    ID = 8,
                    Name = "Strawberry Gummy Candy",
                    Description = "Gumy candy with an amazing strawberry flavor.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 30,
                    Discount = 0,
                    CategoryName = CategoryName.GummyCandies
                },

                new Sweetness
                {
                    ID = 9,
                    Name = "White Chocolate Candy",
                    Description = "Amazing white chocolate.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 30,
                    Discount = 0,
                    CategoryName = CategoryName.Candies
                },

                new Sweetness
                {
                    ID = 10,
                    Name = "Black Chocolate Candy",
                    Description = "Amazing black chocolate.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 3000,
                    Discount = 0,
                    CategoryName = CategoryName.Candies
                },

                new Sweetness
                {
                    ID = 11,
                    Name = "Strawberry Chocolate Candy",
                    Description = "Amazing strawberry chocolate.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 80,
                    Discount = 0,
                    CategoryName = CategoryName.Candies
                },

                new Sweetness
                {
                    ID = 12,
                    Name = "Orange Chocolate Candy",
                    Description = "Amazing orange chocolate.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 0.5M,
                    StockLevel = 300,
                    Discount = 0,
                    CategoryName = CategoryName.Candies
                },

                new Sweetness
                {
                    ID = 13,
                    Name = "Toffee Chocolate Candy",
                    Description = "amazing toffee chocolate.",
                    IsVegan = true,
                    IsGluten = false,
                    CurrentPrice = 1,
                    StockLevel = 300,
                    Discount = 0,
                    CategoryName = CategoryName.Candies
                }
            );

            modelBuilder.Entity<KitContent>().HasData(
                new KitContent
                {
                    ID = 1,
                    Quantity = 2,
                    KitID = 1,
                    SweetnessID = 1
                },

                new KitContent
                {
                    ID = 2,
                    Quantity = 2,
                    KitID = 1,
                    SweetnessID = 2
                },

                new KitContent
                {
                    ID = 3,
                    Quantity = 2,
                    KitID = 1,
                    SweetnessID = 3
                },

                new KitContent
                {
                    ID = 4,
                    Quantity = 15,
                    KitID = 2,
                    SweetnessID = 6
                },

                new KitContent
                {
                    ID = 5,
                    Quantity = 15,
                    KitID = 2,
                    SweetnessID = 7
                },

                new KitContent
                {
                    ID = 6,
                    Quantity = 15,
                    KitID = 2,
                    SweetnessID = 8
                }
            );
        }
    }
}
