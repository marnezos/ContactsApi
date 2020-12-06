using Contacts.Domain.DBModels;

namespace Contacts.Domain.Dal
{
    public interface IContactRepository:IRepository<Contact>
    {
        //Custom contact methods go here
    }
}
