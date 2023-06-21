using System.ComponentModel.DataAnnotations;

namespace CandyShop.Models.DBModels
{
    public class Kit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public int StockLevel { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }

        //Relationships
        public ICollection<KitContent> KitContents { get; set; }
        public ICollection<KitsOnly> KitsOnly { get; set; }

        public Kit() { }

        public Kit(int iD, string name, string description, decimal currentPrice, int stockLevel,
            int discount)
        {
            ID = iD;
            Name = name;
            Description = description;
            CurrentPrice = currentPrice;
            StockLevel = stockLevel;
            Discount = discount;
        }
    }
}
