
using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    /// <summary>
    /// Returns a lite db storage implementation given a config
    /// </summary>
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
