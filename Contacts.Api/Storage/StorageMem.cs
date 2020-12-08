using Contacts.Dal.Mem;
using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    public class StorageMem : StorageImplementation
    {

        private readonly IConfiguration _configuration;
        public StorageMem(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override IContactRepository ContactRepository
        {
            get
            {
                DataLayerInfrastructure<ContactsContext> infrastructure = new Infrastructure();
                infrastructure.EnsureStorageCreated(_configuration);
                return new ContactRepository(infrastructure);
            }
        }

        public override ISkillRepository SkillRepository
        {
            get
            {
                DataLayerInfrastructure<ContactsContext> infrastructure = new Infrastructure();
                infrastructure.EnsureStorageCreated(_configuration);
                return new SkillRepository(infrastructure);
            }
        }
    }
}
