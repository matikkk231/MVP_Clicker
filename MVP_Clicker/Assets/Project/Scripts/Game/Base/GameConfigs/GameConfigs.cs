using Project.Scripts.Game.Areas.BonusesShop.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public class GameConfigs : IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }

        public GameConfigs(IBonusesShopConfig bonusesShopConfig)
        {
            BonusesShopConfig = bonusesShopConfig;
        }
    }
}