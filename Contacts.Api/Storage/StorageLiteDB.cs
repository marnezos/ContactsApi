using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    public class StorageLiteDB : StorageImplementation
    {
        private readonly IConfiguration _configuration;
        public StorageLiteDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override IContactRepository ContactRepository
        {
            get
            {
                DataLayerInfrastructure<ILiteDatabase> infrastructure = new Infrastructure();
                infrastructure.EnsureStorageCreated(_configuration);
                return new ContactRepository(infrastructure);
            }
        }

        public override ISkillRepository SkillRepository
        {
            get
            {
                DataLayerInfrastructure<ILiteDatabase> infrastructure = new Infrastructure();
                infrastructure.EnsureStorageCreated(_configuration);
                return new SkillRepository(infrastructure);
            }
        }
    }
}
