using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement;
using Project.Scripts.Game.Areas.Achievement.Data;
using Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model;
using Project.Scripts.Game.Areas.Achievements.Config;
using Project.Scripts.Game.Areas.Achievements.Data;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.Achievements.Model
{
    public class AchievementsModel : IAchievementsModel
    {
        public Dictionary<string, IAchievementModel> Collection { get; }

        public AchievementsModel(IMonsterModel monsterModel, IAchievementsConfig config, IAchievementsData data)
        {
            if (data.IsInitialized == false)
            {
                InitializeData(data, config);
            }

            Collection = new Dictionary<string, IAchievementModel>();
            foreach (var achievementConfig in config.Collection)
            {
                switch (achievementConfig.Type)
                {
                    case "KillingMonsters":
                        var model = new MonsterKillingAchievementModel(monsterModel, achievementConfig,
                            data.Collection[achievementConfig.Id]);
                        Collection.Add(achievementConfig.Id, model);
                        break;
                    default:
                        throw new Exception("can't create achievement model with such type:" + achievementConfig.Type);
                }
            }
        }

        private void InitializeData(IAchievementsData data, IAchievementsConfig config)
        {
            foreach (var configElement in config.Collection)
            {
                IAchievementData achievementData = new AchievementData();
                achievementData.Id = configElement.Id;
                data.Collection.Add(configElement.Id, achievementData);
            }

            data.IsInitialized = true;
        }
    }
}