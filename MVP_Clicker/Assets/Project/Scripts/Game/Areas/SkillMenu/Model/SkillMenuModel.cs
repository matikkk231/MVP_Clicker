using System.Collections.Generic;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Skill.Config;
using Project.Scripts.Game.Areas.Skill.Model;
using Project.Scripts.Game.Areas.SkillMenu.Config;

namespace Project.Scripts.Game.Areas.SkillMenu.Model
{
    public class SkillMenuModel : ISkillMenuModel
    {
        public Dictionary<string, ISkillModel> Collection { get; set; }

        public SkillMenuModel(IMonsterModel monsterModel, IGameResourceModel damagePerTap,
            ICoroutineStarterService coroutineStarterService, ISkillMenuConfig config)
        {
            Collection = new Dictionary<string, ISkillModel>();
            foreach (var element in config.Collection)
            {
                switch (element.Value.Id)
                {
                    case "VampireSkill":
                        var skill = new VampireSkill(monsterModel, damagePerTap, coroutineStarterService,
                            element.Value);
                        Collection.Add(skill.Id, skill);
                        break;
                }
            }
        }
    }
}