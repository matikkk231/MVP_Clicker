using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.GameResources.Data
{
    public interface IGameResourcesData
    {
        bool IsInitialized { get; set; }
        public IDictionary<string, IGameResourceData> CollectionOfGameResources { get; }
    }
}