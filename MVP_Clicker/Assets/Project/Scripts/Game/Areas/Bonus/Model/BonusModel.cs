using System;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public class BonusModel : IBonusModel
    {
        public event Action Updated;
        public event Action<string> UpgradeBought;
        public event Action DamagePerTapBonusChanged;

        private int _providingDamagePerTapBonus;
        private int _bonusLevel;
        private int _upgradeValue;

        private readonly string _id;

        public int ProvidingDamagePerTapBonus
        {
            get => _providingDamagePerTapBonus;
            set
            {
                _providingDamagePerTapBonus = value;
                Updated?.Invoke();
                DamagePerTapBonusChanged?.Invoke();
            }
        }

        public int UpgradeValue
        {
            get => _upgradeValue;
            set
            {
                _upgradeValue = value;
                Updated?.Invoke();
            }
        }

        public int BonusLevel
        {
            get => _bonusLevel;
            set
            {
                _bonusLevel = value;
                Updated?.Invoke();
            }
        }

        public BonusModel(string id)
        {
            int startBonusLevel = 1;
            BonusLevel = startBonusLevel;

            int startUpgradeValue = 20;
            UpgradeValue = startUpgradeValue;

            int startProvidingDamagePerTapBonus = 1;
            ProvidingDamagePerTapBonus = startProvidingDamagePerTapBonus;

            _id = id;
        }

        public void BuyUpgrade()
        {
            UpgradeBought?.Invoke(_id);
        }

        public void UpdateUpgradeValue()
        {
            UpgradeValue *= 2;
        }

        public void UpdateProvidingBonus()
        {
            ProvidingDamagePerTapBonus++;
        }

        public void UpdateBonusLevel()
        {
            BonusLevel++;
        }
    }
}