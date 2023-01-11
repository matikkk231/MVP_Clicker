using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.BonusesShop.Data
{
    public class BonusesShopData : IBonusesShopData
    {
        [JsonProperty("SwordData")] public BonusData SwordData;

        [JsonProperty("IsBonusesShopDataInitialized")]
        public bool IsInitialized { get; set; }

        public IBonusData Sword => SwordData;

        public BonusesShopData()
        {
            SwordData = new BonusData();
        }
    }
}