using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Config;

namespace Project.Scripts.Game.Areas.BonusesShop.Config
{
    public interface IBonusesShopConfig
    {
        public IDictionary<string, IBonusConfig> CollectionOfBonuses { get; }
    }
}