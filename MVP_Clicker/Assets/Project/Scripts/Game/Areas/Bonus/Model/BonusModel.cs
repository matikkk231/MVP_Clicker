using System;
using Project.Scripts.Game.Areas.Bonus.Config;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public class BonusModel : IBonusModel
    {
        public event Action Updated;
        public event Action<string> UpgradeBought;
        public event Action<int> DamagePerTapBonusChanged;

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
                DamagePerTapBonusChanged?.Invoke(0);
            }
        }

        public string Id => _id;

        public int UpgradeValue
        {
            get => _upgradeValue;
            private set
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

        public BonusModel(IBonusConfig config)
        {
            BonusLevel = config.StartBonusLevel;

            UpgradeValue = config.StartUpgradeValue;

            ProvidingDamagePerTapBonus = config.StartProvidingDamagePerTapBonus;

            _id = config.Id;
        }

        public BonusModel(IBonusData data)
        {
            BonusLevel = data.BonusLevel;

            UpgradeValue = data.UpgradeValue;

            ProvidingDamagePerTapBonus = data.ProvidingDamagePerTapBonus;

            _id = data.Id;
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