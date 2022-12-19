using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Model;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public interface IBonusesShopModel
    {
        Dictionary<string, IBonusModel> Collection { get; }
    }
}