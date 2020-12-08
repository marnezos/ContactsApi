using Contacts.Domain.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Dal.Mem
{
    public class ContactsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("contacts");
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ContactSkill> ContactSkill { get; set; }
        public DbSet<Skill> Skill { get; set; }

    }
}
