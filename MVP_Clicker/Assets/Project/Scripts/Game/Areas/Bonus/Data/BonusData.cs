using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Bonus.Data
{
    public class BonusData : IBonusData
    {
        [JsonProperty("BonusLevelData")] public int BonusLevelData;
        [JsonProperty("UpgradeValueData")] public int UpgradeValueData;

        [JsonProperty("ProvidingDamagePerTapBonusData")]
        public int ProvidingDamagePerTapBonusData;

        [JsonProperty("IdData")] public string IdData;
        
        [JsonIgnore]
        public int BonusLevel
        {
            get => BonusLevelData;
            set => BonusLevelData = value;
        }
        [JsonIgnore]
        public int UpgradeValue
        {
            get => UpgradeValueData;
            set => UpgradeValueData = value;
        }
        [JsonIgnore]
        public int ProvidingDamagePerTapBonus
        {
            get => ProvidingDamagePerTapBonusData;
            set => ProvidingDamagePerTapBonusData = value;
        }
        [JsonIgnore]
        public string Id
        {
            get => IdData;
            set => IdData = value;
        }

        public BonusData()
        {
            IdData = "nothing";
        }
    }
}