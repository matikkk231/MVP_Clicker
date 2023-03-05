using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Model;

namespace Project.Scripts.Game.Areas.Skills.Model
{
    public interface ISkillsModel
    {
        public Dictionary<string, ISkillModel> Collection { get; set; }
    }
}