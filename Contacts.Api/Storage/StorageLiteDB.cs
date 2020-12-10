using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.Api.Storage
{
    /// <summary>
    /// Uses a specific (LiteDB) data layer infrastructure to provide access to repos
    /// </summary>
    public class StorageLiteDB : StorageImplementation, IDisposable
    {
        private readonly bool _disposed = false;
        private readonly IContactRepository _contactRepository;
        private readonly ISkillRepository _skillRepository;

        public StorageLiteDB(IConfiguration configuration)
        {
            //Get references to repos and reuse them for this object's lifetime
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
