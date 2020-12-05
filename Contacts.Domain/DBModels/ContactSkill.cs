﻿using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.DBModels
{
    public class ContactSkill
    {
        public int ContactSkillId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public ProficiencyScale Level { get; set; }
    }

    /// <summary>
    /// https://hr.nih.gov/working-nih/competencies/competencies-proficiency-scale
    /// </summary>
    public enum ProficiencyScale
    {
        Fundamental = 1,
        Novice = 2,
        Intermediate = 3,
        Advanced = 4,
        Expert = 5
    }
}