using Contacts.Domain.Dal;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Ldb
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        private readonly ILiteDatabase _database;
        private readonly ILiteCollection<T> _liteCollection;
        private readonly bool _disposed = false;

        protected BaseRepository(DataLayerInfrastructure<ILiteDatabase> infrastructure)
        {
            _database = infrastructure.NewDbContext();
            _liteCollection = _database.GetCollection<T>();
        }

        public async virtual Task<T> InsertAsync(T data)
        {
            BsonValue id = _liteCollection.Insert(data);
            return _liteCollection.FindById(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return _liteCollection.FindAll();
        }

        public async virtual Task<T> GetAsync(int id)
        {
            return _liteCollection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            _liteCollection.Upsert(entity);
        }

        public async virtual Task DeleteAsync(int id)
        {
            _liteCollection.Delete(id);
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
