using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;
using System.Threading.Tasks;

namespace Contacts.Dal.Ldb
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly ILiteDatabase _database;
        public ContactRepository(DataLayerInfrastructure<ILiteDatabase> infrastructure) : base(infrastructure)
        {
            _database = DatabaseContext;
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
                        //Update existing skill
                        _database.GetCollection<Skill>().Update(cs.Skill);
                    }
                    else
                    {
                        //Insert skill in collection
                        BsonValue newId = _database.GetCollection<Skill>().Insert(cs.Skill);
                        cs.Skill = _database.GetCollection<Skill>().FindById(newId);
                    }
                }
            }
            return await base.InsertAsync(data);
        }
        //Custom contact methods implementations go here
    }
}
