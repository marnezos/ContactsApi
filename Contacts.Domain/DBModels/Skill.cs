using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.DBModels
{

    //Note: Changed the definition of a skill. Multiple contacts may share a single skill, but each one of them 
    //on a different level. Skill level moved to the ContactSkill
    public class Skill
    {
        public int SkillId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

    }
}
