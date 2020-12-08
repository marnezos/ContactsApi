using Contacts.Dal.Ldb;
using Contacts.Domain.Dal;
using Contacts.Domain.DBModels;
using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

            IConfiguration config = configurationBuilder.Build();
            
            _infrastructure.EnsureStorageCreated(config);
        }


        [TestMethod]
        public void DalShouldBeAbleToCreateANewDb()
        {
            //Infra should have a file created at this location
            Assert.IsTrue(File.Exists(_tempDbFilename));
        }

        [TestMethod]
        public async Task AddContactShouldSaveAContactInDB()
        {
            using ContactRepository repo = new ContactRepository(_infrastructure);

            Contact contact = new Contact()
            {
                Email = "blah@example.com",
                FirstName = "blah",
                LastName = "bluh",
                MainAddress = new Address()
                {
                    City = "theCity",
                    CountryCode = "CH",
                    PostalCode = "1233A",
                    Street = "Euler Strasse",
                    Number = "A2"
                }
            };

            contact = await repo.InsertAsync(contact);

            Assert.IsNotNull(contact.ContactId);

        }

        [TestMethod]
        public async Task UpdateContactShouldExhibitChanges()
        {
            using ContactRepository repo = new ContactRepository(_infrastructure);

            Contact contact = new Contact()
            {
                Email = "aaa@example.com",
                FirstName = "test1",
                LastName = "test2 ",
                MainAddress = new Address()
                {
                    City = "Nice City",
                    CountryCode = "CH",
                    PostalCode = "3233A",
                    Street = "Niklaus Wirth Strasse",
                    Number = "B2"
                }
            };

            contact = await repo.InsertAsync(contact);
            int contactId = contact.ContactId;

            //ToDo: Expand test case
            string expectedFirstName = "new name";
            string expectedLastName = "new lastname";
            string expectedEmail = "test@example.com";
            string expectedMainAddressCity = "beautiful city";

            contact.FirstName = expectedFirstName;
            contact.LastName = expectedLastName;
            contact.Email = expectedEmail;
            contact.MainAddress.City = expectedMainAddressCity;

            repo.Update(contact);

            contact = await repo.GetAsync(contactId);

            Assert.AreEqual(contact.FirstName, expectedFirstName);
            Assert.AreEqual(contact.LastName, expectedLastName);
            Assert.AreEqual(contact.Email, expectedEmail);
            Assert.AreEqual(contact.MainAddress.City, expectedMainAddressCity);

        }

        [TestMethod]
        public async Task DeleteContactShouldRemoveContactPermanently()
        {
            using ContactRepository repo = new ContactRepository(_infrastructure);

            Contact contact = new Contact()
            {
                Email = "bbb@example.com",
                FirstName = "test1",
                LastName = "test2 ",
                MainAddress = new Address()
                {
                    City = "Another City",
                    CountryCode = "CH",
                    PostalCode = "6233A",
                    Street = "Testh Strasse",
                    Number = "B3"
                }
            };

            contact = await repo.InsertAsync(contact);
            int contactId = contact.ContactId;

            repo.DeleteAsync(contactId);

            contact = await repo.GetAsync(contactId);
            Assert.IsNull(contact);
        }

        [ClassCleanup]
        public static void TearDownTemporaryObjects()
        {
            //Clean up
            File.Delete(_tempDbFilename);
        }

    }
}
