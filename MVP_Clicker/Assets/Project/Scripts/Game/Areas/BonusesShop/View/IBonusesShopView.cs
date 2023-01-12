using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.View;

namespace Project.Scripts.Game.Areas.BonusesShop.View
{
    public interface IBonusesShopView
    {
        IDictionary<string, IBonusView> CollectionOfBonuses { get; set; }
        public IBonusView CreateBonusView();
    }
}