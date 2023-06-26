namespace CandyShop.Models.DBModels
{
    public class KitContent
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        //Relationships
        public int KitID { get; set; }
        public Kit? Kit { get; set; }
        public int SweetnessID { get; set; }
        public Sweetness? Sweetness { get; set; }

        public KitContent() { }

        public KitContent(int iD, int quantity)
        {
            ID = iD;
            Quantity = quantity;
        }
    }
}
