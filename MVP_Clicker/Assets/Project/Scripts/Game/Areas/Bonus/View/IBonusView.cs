using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Bonus.View
{
    public interface IBonusView
    {
        event Action BoughtUpgrade;
        
        void SetBonusLevel(int currentBonusLevel);
        void SetProvidingBonus(int currentDamagePerTapBonus);
        void SetUpgradeValue(int upgradeValue);
        void SetBonusSprite(Sprite bonusSprite);
    }
}