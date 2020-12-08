using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;

namespace Contacts.Dal.Ldb
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DataLayerInfrastructure<ILiteDatabase> infrastructure) : base(infrastructure)
        {
        }

        //Custom contact methods implementations go here
    }
}
