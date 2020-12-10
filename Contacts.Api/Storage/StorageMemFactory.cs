using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    /// <summary>
    /// Returns a mem db storage implementation given a config
    /// </summary>
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
