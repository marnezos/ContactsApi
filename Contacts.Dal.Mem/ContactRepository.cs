using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Mem
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {

        private readonly ContactsContext _database;

        public ContactRepository(DataLayerInfrastructure<ContactsContext> infrastructure) : base(infrastructure)
        {
            _database = infrastructure.GetDbContext();
        }

        public async override Task<Contact> GetAsync(int id)
        {
            return await ContactsAggregate.FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async override Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await ContactsAggregate.ToListAsync();
        }

        protected IIncludableQueryable<Contact, Skill> ContactsAggregate
        {
            get {
                 return _database.Contact
                .Include(c => c.MainAddress)
                .Include(c => c.ContactSkills)
                .ThenInclude(cs => cs.Skill);
            }
        }

        //Custom contact methods implementations go here
    }
}
