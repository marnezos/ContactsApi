using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Contacts.Dal.Ldb
{
    public class Infrastructure : DataLayerInfrastructure<ILiteDatabase>
    {

        public string  _dbPath { get; set; }

        public override void EnsureStorageCreated(IConfiguration config)
        {
            //Get the path from the settings
            _dbPath = config.GetSection("litedb-path").Value;

            //Create the database file if it doesn't exist yet
            using var db = new LiteDatabase(_dbPath);

            _ = db.GetCollection<Contact>("contact");
            _ = db.GetCollection<Skill>("skill");

        }

        public override ILiteDatabase NewDbContext()
        {
            return new LiteDatabase(_dbPath);
        }
    }
}
