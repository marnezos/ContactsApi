using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;

namespace Contacts.Dal.Mem
{
    /// <summary>
    /// Handles broad db infra tasks
    /// </summary>
    public class Infrastructure : DataLayerInfrastructure<ContactsContext>
    {

        public string  _dbPath { get; set; }

        public override void EnsureStorageCreated(IConfiguration config)
        {
            //Memory DB, nothing to do
        }

        public override ContactsContext GetDbContext()
        {
            return new ContactsContext();
        }
    }
}
