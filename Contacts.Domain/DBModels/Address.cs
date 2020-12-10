using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.DBModels
{
    public class Address
    {
        public int AddressId { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        [Required]
        //ISO-3166-1 Alpha2Code
        [StringLength(2)]
        public string CountryCode { get; set; } //ToDo: use a lookup [Country] table

    }
}
