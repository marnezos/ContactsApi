using Contacts.Domain.Dal;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Dal.Ldb
{
    public class Infrastructure : DataLayerInfrastructure
    {
        public override void EnsureStorageCreated(IConfigurationRoot config)
        {
            //Get the path from the settings
            string dbPath = config.GetSection("litedb-path").Value;

            //Create the database file if it doesn't exist yet
            using var db = new LiteDatabase(dbPath); 
        }
    }
}
