using System.ComponentModel.DataAnnotations;

namespace CandyShop.Models.DBModels
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool isSent { get; set; }

        //customer data info
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string? StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? HomeNumber { get; set; }
        public Country Country { get; set; }
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        //Relationships
        public ICollection<SweetsOnly> SweetsOnly { get; set; } = new List<SweetsOnly>();
        public ICollection<KitsOnly> KitsOnly { get; set; } = new List<KitsOnly>();

        public Order() { }

        public Order(int iD, DateTime executionDate, decimal totalCost, bool isSent, string firstName, 
            string lastName, string contactEmail, string phoneNumber, string? streetName, int buildingNumber, 
            int? homeNumber, Country country, string postalCode)
        {
            ID = iD;
            ExecutionDate = executionDate;
            TotalCost = totalCost;
            this.isSent = isSent;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            PhoneNumber = phoneNumber;
            StreetName = streetName;
            BuildingNumber = buildingNumber;
            HomeNumber = homeNumber;
            Country = country;
            PostalCode = postalCode;
        }
    }

    public enum Country
    {
        Poland,
        Germany,
        UnitedKingdom,
        France,
        Italy,
        Spain,
        Ukraine,
        Netherlands
    }
}
