using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.View;

namespace Project.Scripts.Game.Areas.GameResources.View
{
    public interface IGameResourcesView
    {
        public IDictionary<string, IGameResourceView> CollectionOfGameResources { get; set; }
        public IGameResourceView CreateView();
    }
}