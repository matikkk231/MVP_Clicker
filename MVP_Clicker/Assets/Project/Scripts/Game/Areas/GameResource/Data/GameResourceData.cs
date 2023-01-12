using System;
using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.GameResource.Data
{
    [Serializable]
    public class GameResourceData : IGameResourceData
    {
        [JsonProperty("AmountData")] public int _amount;
        [JsonProperty("IdData")] public string _id;

        [JsonIgnore]
        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        [JsonIgnore]
        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public GameResourceData()
        {
            _amount = 0;
            _id = "Nothing";
        }
    }
}