using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;

namespace Contacts.Dal.Mem
{
    public class Infrastructure : DataLayerInfrastructure<ContactsContext>
    {

        public string  _dbPath { get; set; }

        public override void EnsureStorageCreated(IConfiguration config)
        {
            //Memory DB, nothing to do
        }

        public override ContactsContext NewDbContext()
        {
            return new ContactsContext();
        }
    }
}
