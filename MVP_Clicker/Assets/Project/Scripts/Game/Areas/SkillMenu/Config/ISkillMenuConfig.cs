using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Config;

namespace Project.Scripts.Game.Areas.SkillMenu.Config
{
    public interface ISkillMenuConfig
    {
        public Dictionary<string, ISkillConfig> Collection { get;}
    }
}