using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.BonusesShop.Data
{
    public interface IBonusesShopData
    {
        public bool IsInitialized { get; set; }
        public IDictionary<string, IBonusData> CollectionOfBonuses { get; }
    }
}