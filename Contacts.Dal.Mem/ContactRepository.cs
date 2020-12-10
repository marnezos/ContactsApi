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
            _database = (ContactsContext)DatabaseContext;
        }


        public async override Task<Contact> GetAsync(int id)
        {
            return await ContactsAggregate.FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async override Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await ContactsAggregate.ToListAsync();
        }

        public async override Task<Contact> InsertAsync(Contact data)
        {
            //Always add address but reuse skill
            if (data.ContactSkills != null && data.ContactSkills.Count > 0)
            {
                foreach (ContactSkill cs in data.ContactSkills)
                {
                    if (cs.Skill.SkillId != 0)
                    {
                        _database.Entry(cs.Skill).State = cs.Skill.SkillId == 0 ? EntityState.Added : EntityState.Modified;
                    }
                }
            }
            return await base.InsertAsync(data);
        }

        protected IIncludableQueryable<Contact, Skill> ContactsAggregate
        {
            get
            {
                return _database.Contact
               .Include(c => c.MainAddress)
               .Include(c => c.ContactSkills)
               .ThenInclude(cs => cs.Skill);
            }
        }

        //Custom contact methods implementations go here
    }
}
