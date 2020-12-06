using System;
using System.Collections.Generic;

namespace Contacts.Domain.Dal
{
    public interface IRepository<T>: IDisposable
    {
        T Insert(T data);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
