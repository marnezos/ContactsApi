using System.ComponentModel.DataAnnotations;

namespace Contacts.Api.Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public static implicit operator Domain.DBModels.Skill(Skill skill)
        {
            if (skill == null) return null;
            return new Domain.DBModels.Skill()
            {
                SkillId = skill.SkillId,
                Name = skill.Name
            };
        }

        public static implicit operator Skill(Domain.DBModels.Skill skill)
        {
            if (skill == null) return null;
            return new Skill()
            {
                SkillId = skill.SkillId,
                Name = skill.Name
            };
        }

    }
}
