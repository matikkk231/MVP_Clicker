using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public interface IGameConfigs
    {
        public IBonusesShopConfig BonusesShopConfig { get; }
        public IGameResourcesConfig GameResourcesConfig { get; }
    }
}