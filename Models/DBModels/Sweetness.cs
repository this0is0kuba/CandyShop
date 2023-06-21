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

        //Relationships
        public Category Category { get; set; }
        public ICollection<KitContent> kitContents { get; set; }
        public ICollection<SweetsOnly> sweetsOnly { get; set; }

        public Sweetness() { }

        public Sweetness(int iD, string name, string description, bool isVegan, bool isGluten, 
            decimal currentPrice, int stockLevel, int discount)
        {
            ID = iD;
            Name = name;
            Description = description;
            IsVegan = isVegan;
            IsGluten = isGluten;
            CurrentPrice = currentPrice;
            StockLevel = stockLevel;
            Discount = discount;
        }
    }
}
