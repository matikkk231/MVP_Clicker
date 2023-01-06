using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Bonus.BonusConfig
{
    public class BonusConfig
    {
        [JsonProperty("StartBonusLevel")] public int StartBonusLevel;
        [JsonProperty("StartUpgradeValue")] public int StartUpgradeValue;

        [JsonProperty("StartProvidingDamagePerTapBonus")]
        public int StartProvidingDamagePerTapBonus;
    }
}