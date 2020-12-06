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
        private static string _tempDbFilename;

        [ClassInitialize]
        public static void InitDb(TestContext context)
        {
            DataLayerInfrastructure infrastructure = new Infrastructure();

            _tempDbFilename = $"/{Guid.NewGuid()}.db";

            //Prepare a dummy config for the temporary db file
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("litedb-path", _tempDbFilename)
                });

            IConfigurationRoot config = configurationBuilder.Build();

            infrastructure.EnsureStorageCreated(config);
        }


        [TestMethod]
        public void DalShouldBeAbleToCreateANewDb()
        {
            //Infra should have a file created at this location
            Assert.IsTrue(File.Exists(_tempDbFilename));

        }

        [ClassCleanup]
        public static void TearDownTemporaryObjects()
        {
            //Clean up
            File.Delete(_tempDbFilename);
        }

    }
}
