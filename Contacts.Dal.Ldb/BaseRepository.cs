using Contacts.Domain.Dal;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Dal.Ldb
{
    /// <summary>
    /// Serves as a generic repo handler. Override as necessary.
    /// </summary>
    /// <typeparam name="T">Object Collection Set</typeparam>
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected ILiteDatabase DatabaseContext { get; set; }
        private readonly ILiteCollection<T> _liteCollection;
        private readonly bool _disposed = false;

        protected BaseRepository(DataLayerInfrastructure<ILiteDatabase> infrastructure)
        {
            DatabaseContext = infrastructure.GetDbContext();
            _liteCollection = DatabaseContext.GetCollection<T>();
        }

        public async virtual Task<T> InsertAsync(T data)
        {
            await Task.CompletedTask; //LiteDB Doesn't support Async
            BsonValue id = _liteCollection.Insert(data);
            return _liteCollection.FindById(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            await Task.CompletedTask; //LiteDB Doesn't support Async
            return _liteCollection.FindAll();
        }

        public async virtual Task<T> GetAsync(int id)
        {
            await Task.CompletedTask; //LiteDB Doesn't support Async
            return _liteCollection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            _liteCollection.Upsert(entity);
        }

        public async virtual Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
            _liteCollection.Delete(id);
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
