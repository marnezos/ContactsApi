using Microsoft.Extensions.Configuration;

namespace Contacts.Domain.Dal
{
    public abstract class DataLayerInfrastructure<T>
    {
        /// <summary>
        /// Ensures that the underlying storeage is initialized.
        /// </summary>
        /// <param name="config">Prepare an IConfigurationRoot by building a Configuration builder TODO</param>
        public abstract void EnsureStorageCreated(IConfigurationRoot config);

        public abstract T NewDbContext();

    }
}
