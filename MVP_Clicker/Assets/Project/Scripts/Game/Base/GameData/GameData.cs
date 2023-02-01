using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Achievements.Data;
using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.LevelSystem.Data;
using Project.Scripts.Game.Areas.Monster.Data;

namespace Project.Scripts.Game.Base.GameData
{
    public class GameData : IGameData
    {
        [JsonProperty("GameResourcesData")] public GameResourcesData GameResourcesDataValue;
        [JsonProperty("MonsterData")] public MonsterData MonsterDataValue;
        [JsonProperty("LevelSystemData")] public LevelSystemData LevelSystemDataValue;
        [JsonProperty("BonusesShopData")] public BonusesShopData BonusesShopDataValue;
        [JsonProperty("AchievementsDataa")] public AchievementsData AchievementsDataValue;

        [JsonIgnore] public IGameResourcesData GameResources => GameResourcesDataValue;
        [JsonIgnore] public IMonsterData Monster => MonsterDataValue;
        [JsonIgnore] public ILevelSystemData LevelSystem => LevelSystemDataValue;
        [JsonIgnore] public IBonusesShopData BonusesShop => BonusesShopDataValue;
        public IAchievementsData AchievementsData => AchievementsDataValue;

        public GameData()
        {
            MonsterDataValue = new MonsterData();
            LevelSystemDataValue = new LevelSystemData();
            GameResourcesDataValue = new GameResourcesData();
            BonusesShopDataValue = new BonusesShopData();
            AchievementsDataValue = new AchievementsData();
        }
    }
}