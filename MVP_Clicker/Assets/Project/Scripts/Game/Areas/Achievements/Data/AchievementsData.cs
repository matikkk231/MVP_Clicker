using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Project.Scripts.Game.Areas.Achievement.Data;

namespace Project.Scripts.Game.Areas.Achievements.Data
{
    public class AchievementsData : IAchievementsData
    {
        [JsonProperty("CollectionOfAchievementData")]
        public List<AchievementData> AchievementDataList { get; set; }

        [JsonProperty("IsCollectionOfAchievementDataInitialized")]
        public bool IsInitialized { get; set; }

        [JsonIgnore] public Dictionary<string, IAchievementData> Collection { get; private set; } = new();

        [OnSerializing]
        internal void OnSerialize(StreamingContext context)
        {
            AchievementDataList = Collection.Values.Select(i => (AchievementData)i).ToList();
        }

        [OnDeserialized]
        internal void OnDeserialize(StreamingContext context)
        {
            Collection = AchievementDataList.ToDictionary(k => k.Id, v => (IAchievementData)v);
        }
    }
}