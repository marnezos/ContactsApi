namespace Contacts.Api.Storage
{
    public abstract class StorageImplementationFactory
    {
        public abstract StorageImplementation GetStorageImplementation();
    }
}
