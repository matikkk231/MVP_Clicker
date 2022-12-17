using System;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public interface IBonusModel
    {
        event Action Updated;
        event Action UpgradeBought;
        event Action DamagePerTapBonusChanged;
        int ProvidingDamagePerTapBonus { get; set; }
        int BonusLevel { get; set; }
        int UpgradeValue { get; set; }
        void BuyUpgrade();
    }
}