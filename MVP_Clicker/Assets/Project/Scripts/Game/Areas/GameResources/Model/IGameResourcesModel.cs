using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public interface IGameResourcesModel
    {
        Dictionary<string, IGameResourceModel> Collection { get; }
        
    }
}