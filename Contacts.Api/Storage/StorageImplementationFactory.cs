namespace Contacts.Api.Storage
{
    public abstract class StorageImplementationFactory
    {
        /// <summary>
        /// Describes what a storage implementation factory supports
        /// </summary>
        /// <returns></returns>
        public abstract StorageImplementation GetStorageImplementation();
    }
}
