using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.DBModels
{
    public class Contact
    {
        public int ContactId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public virtual Address MainAddress { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string MobilePhoneNumber { get; set; }
        public virtual ICollection<ContactSkill> ContactSkills { get; set; }
    }
}
