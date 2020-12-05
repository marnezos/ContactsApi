namespace Contacts.Domain.DBModels
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; } //ToDo: use a lookup [Country] table

    }
}
