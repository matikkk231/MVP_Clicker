using System;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public interface IBonusModel
    {
        event Action Updated;
        event Action<string> UpgradeBought;
        event Action<int> DamagePerTapBonusChanged;

        int BonusLevel { get; set; }
        int UpgradeValue { get; }
        int ProvidingDamagePerTapBonus { get; }
        string Id { get; }

        void BuyUpgrade();
        void UpdateUpgradeValue();
        void UpdateProvidingBonus();
        void UpdateBonusLevel();
    }
}