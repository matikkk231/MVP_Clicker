using Newtonsoft.Json;
using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.GameResources.Data
{
    public class GameResourcesData : IGameResourcesData
    {
        [JsonProperty("MoneyData")] public GameResourceData MoneyValue;
        [JsonProperty("DamagePerTapData")] public GameResourceData DamagePerTapValue;

        [JsonProperty("IsGameResourcesDataInitialized")]
        public bool IsInitialized { get; set; }

        public IGameResourceData Money => MoneyValue;
        public IGameResourceData DamagePerTap => DamagePerTapValue;

        public GameResourcesData()
        {
            MoneyValue = new GameResourceData();
            DamagePerTapValue = new GameResourceData();
        }
    }
}