using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Contacts.Dal.Ldb
{
    /// <summary>
    /// Handles broad db infra tasks
    /// </summary>
    public class Infrastructure : DataLayerInfrastructure<ILiteDatabase>
    {
        public string  _dbPath { get; set; }
        private ILiteDatabase _dbContext; 

        public override void EnsureStorageCreated(IConfiguration config)
        {
            //Get the path from the settings
            _dbPath = config.GetSection("litedb-path").Value;

            //Create the database file if it doesn't exist yet
            using var db = new LiteDatabase(_dbPath);

            _ = db.GetCollection<Contact>("contact");
            _ = db.GetCollection<Skill>("skill");
        }

        public override ILiteDatabase GetDbContext()
        {
            //Reuse connection
            if (_dbContext is null)
            {
                _dbContext = new LiteDatabase(_dbPath);
            }
            return _dbContext;
        }
    }
}
