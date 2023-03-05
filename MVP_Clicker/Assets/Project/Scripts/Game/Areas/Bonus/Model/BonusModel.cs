using System;
using Project.Scripts.Game.Areas.Bonus.Config;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.Bonus.Model
{
    public class BonusModel : IBonusModel
    {
        public event Action Updated;
        public event Action<string> UpgradeBought;
        public event Action<int, string> BonusChanged;

        private readonly IBonusData _data;
        private readonly IBonusConfig _config;


        public int ProvidingBonus
        {
            get => _data.ProvidingBonus;
            private set
            {
                _data.ProvidingBonus = value;
                Updated?.Invoke();
                BonusChanged?.Invoke(0, _config.Id);
            }
        }

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
        
        public BonusModel(IBonusData data, IBonusConfig config)
        {
            _data = data;
            _config = config;
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
            ProvidingBonus++;
        }

        public void UpdateBonusLevel()
        {
            BonusLevel++;
        }
    }
}