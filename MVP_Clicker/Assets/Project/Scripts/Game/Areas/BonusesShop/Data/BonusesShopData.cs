using System.Collections.Generic;
using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.BonusesShop.Data
{
    public class BonusesShopData : IBonusesShopData
    {
        [JsonProperty("collectionOfBonusData")]
        public List<BonusData> ListOfBonuses;

        [JsonProperty("IsBonusesShopDataInitialized")]
        public bool IsInitialized { get; set; }

        private readonly Dictionary<string, IBonusData> _collectionOfBonuses = new();

        public IDictionary<string, IBonusData> CollectionOfBonuses
        {
            get
            {
                ConvertListToDictionary(ListOfBonuses);
                return _collectionOfBonuses;
            }
        }

        public BonusesShopData()
        {
            ListOfBonuses = new List<BonusData>();
        }

        private void ConvertListToDictionary(List<BonusData> list)
        {
            foreach (var bonus in list)
            {
                _collectionOfBonuses.Add(bonus.Id, bonus);
            }
        }
    }
}