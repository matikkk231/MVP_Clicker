using System.Collections.Generic;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Skill.Model;
using Project.Scripts.Game.Areas.Skills.Config;

namespace Project.Scripts.Game.Areas.Skills.Model
{
    public class SkillsModel : ISkillsModel
    {
        public Dictionary<string, ISkillModel> Collection { get; set; }

        public SkillsModel(IMonsterModel monsterModel, IGameResourceModel damagePerTap,
            ICoroutineStarterService coroutineStarterService, ISkillsConfig config)
        {
            Collection = new Dictionary<string, ISkillModel>();
            foreach (var element in config.Collection)
            {
                switch (element.Value.Id)
                {
                    case "VampireSkill":
                        var vampireSkillModel = new VampireSkillModel(monsterModel, damagePerTap,
                            coroutineStarterService,
                            element.Value);
                        Collection.Add(vampireSkillModel.Id, vampireSkillModel);
                        break;
                    case "DoubleRewardSkill":
                        var doubleRewardSkillModel =
                            new DoubleRewardSkillModel(monsterModel, coroutineStarterService, element.Value);
                        Collection.Add(doubleRewardSkillModel.Id, doubleRewardSkillModel);
                        break;
                }
            }
        }
    }
}