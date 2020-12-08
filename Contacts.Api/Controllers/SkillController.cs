using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Api.Models;
using Contacts.Domain.Dal;
using Microsoft.AspNetCore.Mvc;


namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        private readonly ISkillRepository _skillRepository;
        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        // GET: api/<SkillController>
        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            return _skillRepository.GetAll().Select(s => (Skill)s);
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            return _skillRepository.Get(id);
        }

        // POST api/<SkillController>
        [HttpPost]
        public void Post([FromBody] Skill value)
        {
            _skillRepository.Insert(value);
        }

        // PUT api/<SkillController>
        [HttpPut]
        public void Put([FromBody] Skill value)
        {
            _skillRepository.Update(value);
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _skillRepository.Delete(id);
        }
    }
}
