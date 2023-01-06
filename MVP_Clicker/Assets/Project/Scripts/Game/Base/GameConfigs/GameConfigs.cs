using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public class GameConfigs : IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }
        public IGameResourcesConfig GameResourcesConfig { get; }

        public GameConfigs(IBonusesShopConfig bonusesShopConfig, IGameResourcesConfig gameResourcesConfig)
        {
            BonusesShopConfig = bonusesShopConfig;
            GameResourcesConfig = gameResourcesConfig;
        }
    }
}