namespace CandyShop.Models.DBModels
{
    public class SweetsOnly
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        //Relationships
        public Sweetness Sweetness { get; set; }
        public Order Order { get; set; }

        public SweetsOnly() { }

        public SweetsOnly(int iD, int quantity)
        {
            ID = iD;
            Quantity = quantity;
        }
    }
}
