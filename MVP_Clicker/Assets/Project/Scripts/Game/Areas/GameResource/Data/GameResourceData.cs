using System;
using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.GameResource.Data
{
    [Serializable]
    public class GameResourceData : IGameResourceData
    {
        [JsonProperty("AmountData")] public int AmountData;
        [JsonProperty("IdData")] public string IdData;

        [JsonIgnore]
        public int Amount
        {
            get => AmountData;
            set => AmountData = value;
        }

        [JsonIgnore]
        public string Id
        {
            get => IdData;
            set => IdData = value;
        }
    }
}