using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Monster.Data
{
    public class MonsterData : IMonsterData

    {
        [JsonProperty("CurrentHpData")] public int CurrentHpValue;
        [JsonProperty("FullHpData")] public int FullHpValue;
        [JsonProperty("RewardForKillingData")] public int RewardForKillngValue;

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
            get => RewardForKillngValue;
            set => RewardForKillngValue = value;
        }

        public MonsterData()
        {
            CurrentHpValue = 0;
            FullHpValue = 0;
            RewardForKillngValue = 0;
        }
    }
}