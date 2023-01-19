using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.BonusesShop.Data
{
    public class BonusesShopData : IBonusesShopData
    {
        private Dictionary<string, IBonusData> _collectionOfBonuses = new();

        [JsonProperty("collectionOfBonusData")]
        public List<BonusData> ListOfBonuses;

        [JsonProperty("IsBonusesShopDataInitialized")]
        public bool IsInitialized { get; set; }
        
        [JsonIgnore] public IDictionary<string, IBonusData> CollectionOfBonuses => _collectionOfBonuses;

        public BonusesShopData()
        {
            ListOfBonuses = new List<BonusData>();
        }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            ListOfBonuses = _collectionOfBonuses.Values.Select(i => (BonusData)i).ToList();
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            _collectionOfBonuses = ListOfBonuses.ToDictionary(k => k.Id, v => (IBonusData)v);
        }
    }
}