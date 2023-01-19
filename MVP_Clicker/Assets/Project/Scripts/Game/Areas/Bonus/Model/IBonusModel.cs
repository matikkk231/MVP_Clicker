using System;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public interface IBonusModel
    {
        event Action Updated;
        event Action<string> UpgradeBought;
        event Action<int, string> BonusChanged;

        int BonusLevel { get; }
        int UpgradeValue { get; }
        int ProvidingBonus { get; }

        void BuyUpgrade();
        void UpdateUpgradeValue();
        void UpdateProvidingBonus();
        void UpdateBonusLevel();
    }
}