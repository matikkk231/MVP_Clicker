using UnityEngine;

namespace Project.Scripts.Game.Areas.Bonus.Config
{
    [CreateAssetMenu(fileName = "NewBonus", menuName = "ScriptableObjects/Bonuses/Bonus")]
    public class BonusConfig : ScriptableObject, IBonusConfig
    {
        [SerializeField] private int _startBonusLevel;
        [SerializeField] private int _startUpgradeValue;
        [SerializeField] private int _startProvidingBonus;
        [SerializeField] private string _id;
        [SerializeField] private string _currencyForUpgrade;
        [SerializeField] private string _typeOfProvidingBonus;
        [SerializeField] private Sprite _bonusSprite;

        public string TypeOfProvidingBonus => _typeOfProvidingBonus;
        public string CurrencyForUpgrade => _currencyForUpgrade;
        public int StartBonusLevel => _startBonusLevel;
        public int StartUpgradeValue => _startUpgradeValue;
        public int StartProvidingBonus => _startProvidingBonus;
        public string Id => _id;
        public Sprite BonusSprite => _bonusSprite;
    }
}