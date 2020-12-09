using Contacts.Domain.Dal;
using System;

namespace Contacts.Api.Storage
{
    public abstract class StorageImplementation:IDisposable
    {
        public abstract IContactRepository ContactRepository {get;}
        public abstract ISkillRepository SkillRepository { get; }
        public abstract void Dispose();
    }
}
