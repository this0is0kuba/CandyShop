namespace CandyShop.Models.DBModels
{
    public class KitsOnly
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        //Relationships
        public int KitID { get; set; }
        public Kit? Kit { get; set; }
        public int OrderID { get; set; }
        public Order? Order { get; set; }

        public KitsOnly() { }

        public KitsOnly(int iD, int quantity)
        {
            ID = iD;
            Quantity = quantity;
        }
    }
}
