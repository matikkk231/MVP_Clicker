using UnityEngine;

namespace Project.Scripts.Game.Areas.Bonus.Config
{
    [CreateAssetMenu(fileName = "NewBonus", menuName = "ScriptableObjects/Bonuses/Bonus")]
    public class BonusConfig : ScriptableObject, IBonusConfig
    {
        [SerializeField] private int _startBonusLevel;
        [SerializeField] private int _startUpgradeValue;
        [SerializeField] private int _startProvidingDamagePerTapBonus;
        [SerializeField] private string _id;
        [SerializeField] private string _currencyForUpgrade;

        public string CurrencyForUpgrade => _currencyForUpgrade;
        public int StartBonusLevel => _startBonusLevel;
        public int StartUpgradeValue => _startUpgradeValue;
        public int StartProvidingDamagePerTapBonus => _startProvidingDamagePerTapBonus;
        public string Id => _id;
    }
}