using System.ComponentModel.DataAnnotations;

namespace CandyShop.Models.DBModels
{
    public class Sweetness
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGluten { get; set;}
        public decimal CurrentPrice { get; set; }
        public int StockLevel { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        public CategoryName CategoryName { get; set; }

        //Relationships
        public ICollection<KitContent> KitContents { get; set; } = new List<KitContent>();
        public ICollection<SweetsOnly> SweetsOnly { get; set; } = new List<SweetsOnly>();

        public Sweetness() { }

        public Sweetness(int iD, string name, string description, bool isVegan, bool isGluten, 
            decimal currentPrice, int stockLevel, int discount, CategoryName categoryName)
        {
            ID = iD;
            Name = name;
            Description = description;
            IsVegan = isVegan;
            IsGluten = isGluten;
            CurrentPrice = currentPrice;
            StockLevel = stockLevel;
            Discount = discount;
            CategoryName = categoryName;
        }
    }

    public enum CategoryName
    {
        Chocolate,
        GummyCandies,
        Lollipops,
        Candies
    }
}
