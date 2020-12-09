using Microsoft.Extensions.Configuration;

namespace Contacts.Domain.Dal
{

    public abstract class DataLayerInfrastructure<T> 
    {
        /// <summary>
        /// Ensures that the underlying storeage is initialized.
        /// </summary>
        /// <param name="config">Prepare an IConfiguration by building a Configuration builder TODO</param>
        public abstract void EnsureStorageCreated(IConfiguration config);

        public abstract T GetDbContext();

    }
}
