using Contacts.Domain.Dal;
using System;

namespace Contacts.Api.Storage
{
    /// <summary>
    /// Describes the injectable object that provides storage repos
    /// </summary>
    public abstract class StorageImplementation:IDisposable
    {
        public abstract IContactRepository ContactRepository {get;}
        public abstract ISkillRepository SkillRepository { get; }
        public abstract void Dispose();
    }
}
