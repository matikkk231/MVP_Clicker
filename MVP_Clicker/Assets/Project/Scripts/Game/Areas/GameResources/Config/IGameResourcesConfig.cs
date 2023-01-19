using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResource.Config;

namespace Project.Scripts.Game.Areas.GameResources.Config
{
    public interface IGameResourcesConfig
    {
        public IDictionary<string, IGameResourceConfig> CollectionOfGameResources { get; }
    }
}