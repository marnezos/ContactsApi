using Contacts.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Tests
{
    [TestClass]
    public class Api_Model_Tests
    {

        [TestMethod]
        public void Contact_MissingData_ShouldNotBeAllowed()
        {
            Contact contact;

            // Valid Contract
            contact = TestModelCreator.NewValidContact();
            Assert.IsTrue(ModelIsValid(contact));

            //Without First Name
            contact = TestModelCreator.NewValidContact();
            contact.FirstName = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Last Name
            contact = TestModelCreator.NewValidContact();
            contact.LastName = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Phonenumber
            contact = TestModelCreator.NewValidContact();
            contact.MobilePhoneNumber = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without ContactSkills
            contact = TestModelCreator.NewValidContact();
            contact.ContactSkills = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Empty ContactSkills
            contact = TestModelCreator.NewValidContact();
            contact.ContactSkills.Clear();
            Assert.IsFalse(ModelIsValid(contact));

            //Without Skill Name
            contact = TestModelCreator.NewValidContact();
            contact.ContactSkills[0].Skill.Name = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Skill
            contact = TestModelCreator.NewValidContact();
            contact.ContactSkills[0].Skill = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Address
            contact = TestModelCreator.NewValidContact();
            contact.MainAddress = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Address Postal Code
            contact = TestModelCreator.NewValidContact();
            contact.MainAddress.PostalCode = null;
            Assert.IsFalse(ModelIsValid(contact));

            //Without Address Country
            contact = TestModelCreator.NewValidContact();
            contact.MainAddress.CountryCode = null;
            Assert.IsFalse(ModelIsValid(contact));

            //ToDo: Expand Tests

        }

        private bool ModelIsValid<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            IDataAnnotationsValidator dataAnnotationsValidator = new DataAnnotationsValidator();
            dataAnnotationsValidator.TryValidateObjectRecursive(model, validationResults, null);
            return validationResults.Count == 0;
        }

    }
}
