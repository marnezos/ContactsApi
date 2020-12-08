using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;

namespace Contacts.Dal.Mem
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DataLayerInfrastructure<ContactsContext> infrastructure) : base(infrastructure)
        {
        }

        //Custom contact methods implementations go here
    }
}
