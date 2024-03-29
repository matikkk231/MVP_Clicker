using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Monster.Data
{
    public class MonsterData : IMonsterData

    {
        [JsonProperty("IsMonsterDataInitialized")]
        public bool IsInitialized { get; set; }

        [JsonProperty("CurrentHpData")] public int CurrentHpValue;
        [JsonProperty("FullHpData")] public int FullHpValue;
        [JsonProperty("RewardForKillingData")] public int RewardForKillingValue;


        public int CurrentHp
        {
            get => CurrentHpValue;
            set => CurrentHpValue = value;
        }

        public int FullHp
        {
            get => FullHpValue;
            set => FullHpValue = value;
        }

        public int RewardForKilling
        {
            get => RewardForKillingValue;
            set => RewardForKillingValue = value;
        }
    }
}