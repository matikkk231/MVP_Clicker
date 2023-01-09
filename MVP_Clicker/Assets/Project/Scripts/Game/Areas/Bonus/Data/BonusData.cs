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

        public int BonusLevel
        {
            get => BonusLevelData;
            set => BonusLevelData = value;
        }

        public int UpgradeValue
        {
            get => UpgradeValueData;
            set => UpgradeValueData = value;
        }

        public int ProvidingDamagePerTapBonus
        {
            get => ProvidingDamagePerTapBonusData;
            set => ProvidingDamagePerTapBonusData = value;
        }

        public string Id
        {
            get => IdData;
            set => IdData = value;
        }

        public BonusData()
        {
            BonusLevelData = 0;
            UpgradeValueData = 0;
            ProvidingDamagePerTapBonusData = 0;
            IdData = "Nothing";
        }
    }
}