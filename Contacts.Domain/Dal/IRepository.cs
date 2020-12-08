using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Dal
{
    public interface IRepository<T>: IDisposable
    {
        Task<T> InsertAsync(T data);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}
