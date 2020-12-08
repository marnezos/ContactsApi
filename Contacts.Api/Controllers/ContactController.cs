using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Contacts.Api.Models;
using Contacts.Domain.Dal;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISkillRepository _skillRepository;

        public ContactController(IContactRepository contactRepository, ISkillRepository skillRepository)
        {
            _contactRepository = contactRepository;
            _skillRepository = skillRepository;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetAll().Select(c => (Contact)c);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactRepository.Get(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            _contactRepository.Insert(value);
            foreach (ContactSkill contactSkill in value.ContactSkills)
            {
                _skillRepository.Update(contactSkill.Skill);
            }
        }

        // PUT api/<ContactController>
        [HttpPut]
        public void Put([FromBody] Contact value)
        {
            _contactRepository.Update(value);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }
    }
}
