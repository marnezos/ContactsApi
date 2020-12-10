using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Api.Models;
using Contacts.Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //No need to check ModelState.IsValid
    public class ContactController : ControllerBase
    {
        private readonly StorageImplementation _storageImplementation;
        public ContactController(StorageImplementation storageImplementation)
        {
            _storageImplementation = storageImplementation;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAsync()
        {
            IEnumerable<Domain.DBModels.Contact> contacts = await _storageImplementation.ContactRepository.GetAllAsync();
            return contacts.Select(c => (Contact)c);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<Contact> GetAsync(int id)
        {
            return await _storageImplementation.ContactRepository.GetAsync(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<Contact> PostAsync([FromBody] Contact value)
        {
           return await _storageImplementation.ContactRepository.InsertAsync(value);           
        }

        // PUT api/<ContactController>
        [HttpPut]
        public void Put([FromBody] Contact value)
        {
            _storageImplementation.ContactRepository.Update(value);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _storageImplementation.ContactRepository.DeleteAsync(id);
        }

    }
}
