using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.GameResources.Data
{
    public class GameResourcesData : IGameResourcesData
    {
        private IDictionary<string, IGameResourceData>
            _dictionaryWithData = new Dictionary<string, IGameResourceData>();
        [JsonProperty("GameResourcesData")] public List<GameResourceData> CollectionOfGameResourcesData { get; set; }

        [JsonProperty("IsGameResourcesDataInitialized")]
        public bool IsInitialized { get; set; }
        
        [JsonIgnore] public IDictionary<string, IGameResourceData> CollectionOfGameResources => _dictionaryWithData;

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            CollectionOfGameResourcesData = _dictionaryWithData.Values.Select(i => (GameResourceData)i).ToList();
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            _dictionaryWithData = CollectionOfGameResourcesData.ToDictionary(k => k.Id, v => (IGameResourceData)v);
        }
    }
}