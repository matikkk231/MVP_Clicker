using Newtonsoft.Json;
using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.LevelSystem.Data;
using Project.Scripts.Game.Areas.Monster.Data;

namespace Project.Scripts.Game.Base.GameData
{
    public class GameData : IGameData
    {
        [JsonProperty("IsGameDataInitialized")]
        public bool IsDataInitialized { get; set; }

        [JsonProperty("GameResourcesData")] public GameResourcesData GameResourcesDataValue;
        [JsonProperty("MonsterData")] public MonsterData MonsterDataValue;
        [JsonProperty("LevelSystemData")] public LevelSystemData LevelSystemDataValue;
        [JsonProperty("BonusesShopData")] public BonusesShopData BonusesShopDataValue;

        public IGameResourcesData GameResources => GameResourcesDataValue;
        public IMonsterData Monster => MonsterDataValue;
        public ILevelSystemData LevelSystem => LevelSystemDataValue;
        public IBonusesShopData BonusesShop => BonusesShopDataValue;

        public GameData()
        {
            MonsterDataValue = new MonsterData();
            LevelSystemDataValue = new LevelSystemData();
            GameResourcesDataValue = new GameResourcesData();
            BonusesShopDataValue = new BonusesShopData();
        }
    }
}