using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    public class StorageMemFactory : StorageImplementationFactory
    {
        private readonly IConfiguration _configuration;
        public StorageMemFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override StorageImplementation GetStorageImplementation()
        {
            return new StorageMem(_configuration);
        }
    }
}
