namespace CandyShop.Models.DBModels
{
    public class Category
    {
        public int ID { get; set; }
        public CategoryName categoryName { get; set; }
        
        //Relationships
        public ICollection<Sweetness> Sweets { get; set; }

        public Category() {}

        public Category(int ID, CategoryName categoryName)
        {
            this.ID = ID;
            this.categoryName = categoryName;
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
