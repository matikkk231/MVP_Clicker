using Project.Scripts.Game.Areas.Bonus.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.BonusesShop.Config
{
    [CreateAssetMenu(fileName = "BonusesShop", menuName = "ScriptableObjects/BonusesShop")]
    public class BonusesShopConfig : ScriptableObject, IBonusesShopConfig
    {
        [SerializeField] private BonusConfig _sword;

        public IBonusConfig Sword => _sword;
    }
}