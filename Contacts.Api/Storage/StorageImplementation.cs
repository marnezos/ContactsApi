using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;

namespace Contacts.Api.Storage
{
    public abstract class StorageImplementation
    {
        public abstract IContactRepository ContactRepository {get;}
        public abstract ISkillRepository SkillRepository { get; }
    }
}
