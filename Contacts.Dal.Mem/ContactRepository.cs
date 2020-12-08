using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;

namespace Contacts.Dal.Mem
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DataLayerInfrastructure<ContactsContext> infrastructure) : base(infrastructure)
        {
        }

        //Custom contact methods implementations go here
    }
}
