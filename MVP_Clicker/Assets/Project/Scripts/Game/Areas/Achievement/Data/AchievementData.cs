using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Achievement.Data
{
    public class AchievementData : IAchievementData
    {
        [JsonProperty("CurrentPoints")] public int CurrentPoints { get; set; }
        [JsonProperty("AchievementId")] public string Id { get; set; }
    }
}