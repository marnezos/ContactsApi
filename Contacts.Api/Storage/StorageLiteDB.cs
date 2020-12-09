using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.Api.Storage
{
    public class StorageLiteDB : StorageImplementation
    {
        private readonly bool _disposed = false;
        private readonly IContactRepository _contactRepository;
        private readonly ISkillRepository _skillRepository;

        public StorageLiteDB(IConfiguration configuration)
        {
            DataLayerInfrastructure<ILiteDatabase> infrastructure = new Infrastructure();
            infrastructure.EnsureStorageCreated(configuration);
            _contactRepository = new ContactRepository(infrastructure);
            _skillRepository = new SkillRepository(infrastructure);
        }

        public override IContactRepository ContactRepository
        {
            get
            {
                return _contactRepository;
            }
        }

        public override ISkillRepository SkillRepository
        {
            get
            {
                return _skillRepository;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _contactRepository.Dispose();
                    _skillRepository.Dispose();
                }
            }
        }
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
