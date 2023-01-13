using UnityEngine;

namespace Project.Scripts.Game.Areas.Bonus.Config
{
    public interface IBonusConfig
    {
        public int StartBonusLevel { get; }
        public int StartUpgradeValue { get; }
        public int StartProvidingBonus { get; }
        public string Id { get; }
        public string CurrencyForUpgrade { get; }
        public string TypeOfProvidingBonus { get; }
        public Sprite BonusSprite { get; }
    }
}