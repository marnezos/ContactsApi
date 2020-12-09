using Contacts.Domain.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Api.Models
{
    public class ContactSkill
    {
        public int ContactSkillId { get; set; }

        [Required]
        public virtual Skill Skill { get; set; }

        [Required]
        public ProficiencyScale Level { get; set; }

        public static implicit operator Domain.DBModels.ContactSkill(ContactSkill contactSkill)
        {
            if (contactSkill  == null) return null;
            return new Domain.DBModels.ContactSkill()
            {
                ContactSkillId = contactSkill.ContactSkillId,
                Level = contactSkill.Level,
                Skill = contactSkill.Skill
            };
        }

        public static implicit operator ContactSkill (Domain.DBModels.ContactSkill contactSkill)
        {
            if (contactSkill == null) return null;
            return new ContactSkill()
            {
                ContactSkillId = contactSkill.ContactSkillId,
                Level = contactSkill.Level,
                Skill = contactSkill.Skill
            };
        }
    }

}
