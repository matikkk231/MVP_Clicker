using Project.Scripts.Game.Areas.Achievements.Config;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;
using Project.Scripts.Game.Areas.Skills.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public interface IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }
        public IGameResourcesConfig GameResourcesConfig { get; }
        public IMonsterConfig MonsterConfig { get; }
        public IAchievementsConfig Achievements { get; }
        public ISkillsConfig SkillsConfig { get; }
    }
}