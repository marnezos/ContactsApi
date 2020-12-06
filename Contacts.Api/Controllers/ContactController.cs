using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Contacts.Api.Models;
using Contacts.Domain.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
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
