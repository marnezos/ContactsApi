using Contacts.Api.Models;
using System.Collections.Generic;

namespace Contacts.Tests
{
    public static class TestModelCreator
    {
        public static Contact NewValidContact(string firstName = "firstname")
        {
            return new Contact()
            {
                Email = "test@example.com",
                FirstName = firstName,
                LastName = "lastname",
                MainAddress = new Address()
                {
                    City = "City",
                    CountryCode = "XX",
                    Number = "42",
                    PostalCode = "11111",
                    Street = "Street"
                },
                MobilePhoneNumber = "123123123123",
                ContactSkills = new List<ContactSkill>()
                {
                   new ContactSkill()
                   {
                       Level = Domain.DBModels.ProficiencyScale.Novice,
                       Skill = new Skill()
                       {
                           Name ="Super Skill"
                       }
                   }
                }
            };
        }
    }
}
