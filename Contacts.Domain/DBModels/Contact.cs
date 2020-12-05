using System.Collections.Generic;

namespace Contacts.Domain.DBModels
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public virtual Address MainAddress { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public virtual ICollection<ContactSkill> Skills { get; set; }
    }
}
