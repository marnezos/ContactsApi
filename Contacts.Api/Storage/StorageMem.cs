using Contacts.Dal.Mem;
using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.Api.Storage
{
    public class StorageMem : StorageImplementation
    {
        private readonly bool _disposed = false;
        private readonly IContactRepository _contactRepository;
        private readonly ISkillRepository _skillRepository;

        public StorageMem(IConfiguration configuration)
        {
            DataLayerInfrastructure<ContactsContext> infrastructure = new Infrastructure();
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
