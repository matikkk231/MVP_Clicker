using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Config;

namespace Project.Scripts.Game.Areas.Skills.Config
{
    public interface ISkillsConfig
    {
        public Dictionary<string, ISkillConfig> Collection { get;}
    }
}