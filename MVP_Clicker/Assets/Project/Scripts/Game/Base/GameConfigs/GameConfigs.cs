using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public class GameConfigs : IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }
        public IGameResourcesConfig GameResourcesConfig { get; }
        public IMonsterConfig MonsterConfig { get; }

        public GameConfigs(IBonusesShopConfig bonusesShopConfig, IGameResourcesConfig gameResourcesConfig, IMonsterConfig monsterConfig)
        {
            BonusesShopConfig = bonusesShopConfig;
            GameResourcesConfig = gameResourcesConfig;
            MonsterConfig = monsterConfig;
        }
    }
}