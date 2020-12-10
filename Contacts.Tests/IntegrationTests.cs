using Contacts.Api.Controllers;
using Contacts.Api.Models;
using Contacts.Api.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private static string _tempDbFilename;
        private static StorageImplementation _storage;

        [ClassInitialize]
        public static void InitStorage(TestContext context)
        {
            _tempDbFilename = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.db");

            //Prepare a dummy config for the temporary db file
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("litedb-path", _tempDbFilename)
                });

            IConfiguration config = configurationBuilder.Build();

            _storage = new StorageLiteDBFactory(config).GetStorageImplementation();
        }


        [TestMethod]
        public async Task Contact_InsertNewContact_ShouldBeAbleToRetrieveItBack()
        {
            ContactController controller = new ContactController(_storage);
            Contact contact = TestModelCreator.NewValidContact(Guid.NewGuid().ToString());
            Contact insertedContact  = await controller.PostAsync(contact);
            Assert.AreEqual(contact.FirstName, insertedContact.FirstName);
        }




        [ClassCleanup]
        public static void TearDownTemporaryObjects()
        {
            _storage.Dispose();
            //Clean up
            File.Delete(_tempDbFilename);
        }

    }
}
