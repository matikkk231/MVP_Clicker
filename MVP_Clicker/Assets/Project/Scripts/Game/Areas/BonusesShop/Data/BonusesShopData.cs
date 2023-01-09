using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Bonus.Data;

namespace Project.Scripts.Game.Areas.BonusesShop.Data
{
    public class BonusesShopData : IBonusesShopData
    {
        [JsonProperty("SwordData")] public BonusData SwordData;

        public IBonusData Sword => SwordData;

        public BonusesShopData()
        {
            SwordData = new BonusData();
        }
    }
}