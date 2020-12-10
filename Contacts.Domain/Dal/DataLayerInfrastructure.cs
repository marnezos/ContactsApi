using Microsoft.Extensions.Configuration;

namespace Contacts.Domain.Dal
{

    public abstract class DataLayerInfrastructure<T> 
    {
        /// <summary>
        /// Ensures that the underlying storeage is initialized.
        /// </summary>
        /// <param name="config">Prepare an IConfiguration by building a Configuration builder</param>
        public abstract void EnsureStorageCreated(IConfiguration config);

        /// <summary>
        /// Returns a DbContext to be used for creating repositories
        /// </summary>
        /// <returns>Implementation specific database context</returns>
        public abstract T GetDbContext();

    }
}
