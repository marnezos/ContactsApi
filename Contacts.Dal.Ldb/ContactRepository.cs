using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;

namespace Contacts.Dal.Ldb
{
    public class ContactRepository : BaseRepository<Contact>
    {
        public ContactRepository(DataLayerInfrastructure<ILiteDatabase> infrastructure) : base(infrastructure)
        {
        }

        //Custom contact methods implementations go here
    }
}
