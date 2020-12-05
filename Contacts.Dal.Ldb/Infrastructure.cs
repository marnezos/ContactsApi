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
            string dbPath = config.GetSection("litedb-path").Value;
            using var db = new LiteDatabase(dbPath); 
        }
    }
}
