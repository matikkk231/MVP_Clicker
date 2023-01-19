using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.BonusesShop.Config
{
    [CreateAssetMenu(fileName = "BonusesShop", menuName = "ScriptableObjects/BonusesShop")]
    public class BonusesShopConfig : ScriptableObject, IBonusesShopConfig
    {
        [SerializeField] private List<BonusConfig> _collectionOfBonuses;
        public IDictionary<string, IBonusConfig> CollectionOfBonuses => ConvertListTiDictionary(_collectionOfBonuses);

        private IDictionary<string, IBonusConfig> ConvertListTiDictionary(List<BonusConfig> collection)
        {
            Dictionary<string, IBonusConfig> dictionaryWithBonuses = new();
            foreach (var bonus in collection)
            {
                dictionaryWithBonuses.Add(bonus.Id, bonus);
            }

            return dictionaryWithBonuses;
        }
    }
}