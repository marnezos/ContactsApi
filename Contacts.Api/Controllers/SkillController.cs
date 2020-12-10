using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Api.Models;
using Contacts.Api.Storage;
using Contacts.Domain.Dal;
using Microsoft.AspNetCore.Mvc;


namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//No need to check ModelState.IsValid
    public class SkillController : ControllerBase
    {

        private readonly StorageImplementation _storageImplementation;
        public SkillController(StorageImplementation storageImplementation)
        {
            _storageImplementation = storageImplementation;
        }

        // GET: api/<SkillController>
        [HttpGet]
        public async Task<IEnumerable<Skill>> GetAsync()
        {
            IEnumerable<Domain.DBModels.Skill> skills = await _storageImplementation.SkillRepository.GetAllAsync();
            return skills.Select(s => (Skill)s);
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public async Task<Skill> GetAsync(int id)
        {
            return await _storageImplementation.SkillRepository.GetAsync(id);
        }

        // POST api/<SkillController>
        [HttpPost]
        public async Task PostAsync([FromBody] Skill value)
        {
            await _storageImplementation.SkillRepository.InsertAsync(value);
        }

        // PUT api/<SkillController>
        [HttpPut]
        public void Put([FromBody] Skill value)
        {
            _storageImplementation.SkillRepository.Update(value);
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _storageImplementation.SkillRepository.DeleteAsync(id);
        }
    }
}
