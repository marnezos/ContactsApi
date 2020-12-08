using Contacts.Domain.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public virtual T Insert(T data)
        {
            _database.Add(data);
            _database.SaveChanges();
            return data;
        }

        public virtual  IEnumerable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public virtual T Get(int id)
        {
            return _database.Find<T>(id);
        }

        public virtual void Update(T entity)
        {
            _database.Update(entity);
            _database.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T entity = _database.Find<T>(id);
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
