namespace CandyShop.Models.DBModels
{
    public class KitContent
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        //Relationships
        public Kit kit { get; set; }
        public Sweetness sweetness { get; set; }

        public KitContent() { }

        public KitContent(int iD, int quantity)
        {
            ID = iD;
            Quantity = quantity;
        }
    }
}
