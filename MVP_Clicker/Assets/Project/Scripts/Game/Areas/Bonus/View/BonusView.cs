using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Bonus.View
{
    public class BonusView : MonoBehaviour, IBonusView
    {
        public event Action BoughtUpgrade;

        [SerializeField] private TextMeshProUGUI _bonusLevelText;
        [SerializeField] private TextMeshProUGUI _damagePerTapBonusText;
        [SerializeField] private TextMeshProUGUI _upgradeValueText;


        public void SetBonusLevel(int currentBonusLevel)
        {
            _bonusLevelText.text = "level:" + Convert.ToString(currentBonusLevel);
        }

        public void SetDamagePerTapBonus(int currentDamagePerTapBonus)
        {
            _damagePerTapBonusText.text = "DPT bonus:" + Convert.ToString(currentDamagePerTapBonus);
        }

        public void SetUpgradeValue(int upgradeValue)
        {
            _upgradeValueText.text = "upgrade's value:" + Convert.ToString(upgradeValue);
        }

        public void BuyUpgrade()
        {
            BoughtUpgrade?.Invoke();
        }
    }
}