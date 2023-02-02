using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Model;

namespace Project.Scripts.Game.Areas.SkillMenu.Model
{
    public interface ISkillMenuModel
    {
        public Dictionary<string, ISkillModel> Collection { get; set; }
    }
}