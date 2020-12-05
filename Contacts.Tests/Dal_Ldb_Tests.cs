using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Contacts.Tests
{
    [TestClass]
    public class Dal_Ldb_Tests
    {
        [TestMethod]
        public void DalShouldBeAbleToCreateANewDb()
        {
            DataLayerInfrastructure infrastructure = new Infrastructure();

            string tempDbFilename = $"/{Guid.NewGuid()}.db";

            //Prepare a dummy config for the temporary db file
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string,string>>()
                {
                    new KeyValuePair<string, string>("litedb-path", tempDbFilename)
                });

            IConfigurationRoot config = configurationBuilder.Build();

            infrastructure.EnsureStorageCreated(config);

            Assert.IsTrue(File.Exists(tempDbFilename));

            File.Delete(tempDbFilename);

        }
    }
}
