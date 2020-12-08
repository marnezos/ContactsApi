using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contacts.Api.Models
{
    public class Contact
    {
        public int? ContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)] //Changed the requirements here a bit. Fullname is composed of First + Lastname
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        [Required]
        public virtual Address MainAddress { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhoneNumber { get; set; }

        public virtual List<ContactSkill> ContactSkills { get; set; }


        public static implicit operator Domain.DBModels.Contact (Contact contact)
        {
            if (contact == null) return null;
            return new Domain.DBModels.Contact()
            {
                ContactId = (int)contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobilePhoneNumber = contact.MobilePhoneNumber,
                MainAddress = contact.MainAddress,
                ContactSkills = contact.ContactSkills?.Select(cs => (Domain.DBModels.ContactSkill)cs).ToList()
            };
        }

        public static implicit operator Contact (Domain.DBModels.Contact contact)
        {
            if (contact == null) return null;
            return new Contact()
            {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobilePhoneNumber = contact.MobilePhoneNumber,
                MainAddress = contact.MainAddress,
                ContactSkills = contact.ContactSkills?.Select(cs => (ContactSkill)cs).ToList()
            };
        }

    }
}
