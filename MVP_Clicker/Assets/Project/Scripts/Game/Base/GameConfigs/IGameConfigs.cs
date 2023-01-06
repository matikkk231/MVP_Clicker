using Project.Scripts.Game.Areas.Bonus.Config;
using Project.Scripts.Game.Areas.BonusesShop.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public interface IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }
    }
}