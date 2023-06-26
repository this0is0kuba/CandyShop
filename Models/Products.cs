using CandyShop.Models.DBModels;

namespace CandyShop.Models
{
    public class Products
    {
        public ICollection<Kit>? Kits { get; set; }
        public ICollection<Sweetness>? Sweets { get; set; }
    }
}
