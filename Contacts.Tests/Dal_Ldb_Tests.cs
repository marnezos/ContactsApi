using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;
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
        private static DataLayerInfrastructure<ILiteDatabase> _infrastructure;

        [ClassInitialize]
        public static void InitDb(TestContext context)
        {
            _infrastructure = new Infrastructure();

            _tempDbFilename = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.db");

            //Prepare a dummy config for the temporary db file
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("litedb-path", _tempDbFilename)
                });

            IConfigurationRoot config = configurationBuilder.Build();

            _infrastructure.EnsureStorageCreated(config);
        }


        [TestMethod]
        public void DalShouldBeAbleToCreateANewDb()
        {
            //Infra should have a file created at this location
            Assert.IsTrue(File.Exists(_tempDbFilename));
        }

        [TestMethod]
        public void AddContactShouldSaveAContactInDB()
        {
            using ContactRepository repo = new ContactRepository(_infrastructure);

            Contact contact = new Contact()
            {
                Email="blah@example.com",
                FirstName="blah",
                LastName = "bluh",
                FullName = "Mr Blah Bluh",
                MainAddress  = new Address()
                {
                    City ="theCity",
                    CountryCode = "CH",
                    PostalCode="1233A",
                    Street="Euler Strasse",
                    Number="A2"
                }
            };

            contact = repo.Insert(contact);

            Assert.IsNotNull(contact.ContactId);
            
        }

        [ClassCleanup]
        public static void TearDownTemporaryObjects()
        {
            //Clean up
            File.Delete(_tempDbFilename);
        }

    }
}
