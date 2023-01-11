using System;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public class BonusModel : IBonusModel
    {
        public event Action Updated;
        public event Action<string> UpgradeBought;
        public event Action<int> DamagePerTapBonusChanged;

        private readonly IBonusData _data;


        public int ProvidingDamagePerTapBonus
        {
            get => _data.ProvidingDamagePerTapBonus;
            set
            {
                _data.ProvidingDamagePerTapBonus = value;
                Updated?.Invoke();
                DamagePerTapBonusChanged?.Invoke(0);
            }
        }

        public string Id => _data.Id;

        public int UpgradeValue
        {
            get => _data.UpgradeValue;
            private set
            {
                _data.UpgradeValue = value;
                Updated?.Invoke();
            }
        }

        public int BonusLevel
        {
            get => _data.BonusLevel;
            set
            {
                _data.BonusLevel = value;
                Updated?.Invoke();
            }
        }

        public BonusModel(IBonusData data)
        {
            _data = data;
        }

        public void BuyUpgrade()
        {
            UpgradeBought?.Invoke(_data.Id);
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