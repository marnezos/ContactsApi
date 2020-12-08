
using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    public class StorageLiteDBFactory : StorageImplementationFactory
    {
        private readonly IConfiguration _configuration;
        public StorageLiteDBFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override StorageImplementation GetStorageImplementation()
        {
            return new StorageLiteDB(_configuration);
        }
    }
}
