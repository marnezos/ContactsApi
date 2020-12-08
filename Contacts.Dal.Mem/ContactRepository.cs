using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Mem
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {

        private readonly ContactsContext _database;

        public ContactRepository(DataLayerInfrastructure<ContactsContext> infrastructure) : base(infrastructure)
        {
            _database = infrastructure.NewDbContext();
        }

        public async override Task<Contact> GetAsync(int id)
        {
            return await _database.Contact
                .Include(c=>c.MainAddress)
                .Include(c => c.ContactSkills)
                .ThenInclude(cs => cs.Skill).FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async override Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _database.Contact
                .Include(c => c.MainAddress)
                .Include(c => c.ContactSkills)
                .ThenInclude(cs => cs.Skill).ToListAsync();
        }
        //Custom contact methods implementations go here
    }
}
