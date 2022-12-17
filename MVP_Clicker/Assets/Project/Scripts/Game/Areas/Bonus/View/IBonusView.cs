using System;

namespace Project.Scripts.Game.Areas.Bonus.View
{
    public interface IBonusView
    {
        event Action BoughtUpgrade;
        void SetBonusLevel(int currentBonusLevel);
        void SetDamagePerTapBonus(int currentDamagePerTapBonus);
        void SetUpgradeValue(int upgradeValue);
    }
}