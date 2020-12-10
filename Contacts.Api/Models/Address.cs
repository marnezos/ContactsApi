using System.ComponentModel.DataAnnotations;

namespace Contacts.Api.Models
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

        /// <summary>
        /// ISO-3166-1 Alpha2Code
        /// </summary>
        [Required]
        [StringLength(2)]
        public string CountryCode { get; set; } //ToDo: use a lookup [Country] table

        public static implicit operator Domain.DBModels.Address (Address address)
        {
            if (address == null) return null;
            return new Domain.DBModels.Address()
            {
                AddressId = address.AddressId,
                City = address.City,
                CountryCode = address.CountryCode,
                Number = address.CountryCode,
                PostalCode = address.PostalCode,
                Street = address.Street
            };
        }

        public static implicit operator Address(Domain.DBModels.Address address)
        {
            if (address == null) return null;
            return new Address()
            {
                AddressId = address.AddressId,
                City = address.City,
                CountryCode = address.CountryCode,
                Number = address.CountryCode,
                PostalCode = address.PostalCode,
                Street = address.Street
            };
        }

    }
}
