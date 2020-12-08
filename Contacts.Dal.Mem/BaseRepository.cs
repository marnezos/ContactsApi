using Contacts.Domain.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Mem
{
    public abstract class BaseRepository<T> : IRepository<T> where T:class
    {
        private readonly DbContext _database;
        private readonly bool _disposed = false;

        protected BaseRepository(DataLayerInfrastructure<ContactsContext> infrastructure)
        {
            _database = infrastructure.NewDbContext();
        }

        public async virtual Task<T> InsertAsync(T data)
        {
            _database.Add(data);
            await _database.SaveChangesAsync();
            return data;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _database.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetAsync(int id)
        {
            return await _database.FindAsync<T>(id);
        }

        public virtual void Update(T entity)
        {
            _database.Update(entity);
            _database.SaveChanges();
        }

        public async virtual Task DeleteAsync(int id)
        {
            T entity = await _database.FindAsync<T>(id);
            _database.Remove<T>(entity);
            _database.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _database.Dispose();
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
