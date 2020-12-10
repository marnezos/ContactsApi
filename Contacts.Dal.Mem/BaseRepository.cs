using Contacts.Domain.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Mem
{
    /// <summary>
    /// Serves as a generic repo handler. Override as necessary.
    /// </summary>
    /// <typeparam name="T">Entity Collection Set</typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T:class
    {
        protected DbContext DatabaseContext { get; set; }
        private readonly bool _disposed = false;

        protected BaseRepository(DataLayerInfrastructure<ContactsContext> infrastructure)
        {
            DatabaseContext = infrastructure.GetDbContext();
        }

        public async virtual Task<T> InsertAsync(T data)
        {
            DatabaseContext.Add(data);
            await DatabaseContext.SaveChangesAsync();
            return data;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await DatabaseContext.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetAsync(int id)
        {
            return await DatabaseContext.FindAsync<T>(id);
        }

        public virtual void Update(T entity)
        {
            DatabaseContext.Update(entity);
            DatabaseContext.SaveChanges();
        }

        public async virtual Task DeleteAsync(int id)
        {
            T entity = await DatabaseContext.FindAsync<T>(id);
            DatabaseContext.Remove<T>(entity);
            DatabaseContext.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DatabaseContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
