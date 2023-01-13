using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResource.Data;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        private readonly IGameResourcesData _data;
        private readonly IGameResourcesConfig _configs;
        public Dictionary<string, IGameResourceModel> CollectionOfGameResourceModels { get; } = new();
        
        public GameResourcesModel(IGameResourcesData data, IGameResourcesConfig configs)
        {
            _data = data;
            _configs = configs;
            if (_data.IsInitialized)
            {
                foreach (var resource in _configs.CollectionOfGameResources)
                {
                    CollectionOfGameResourceModels.Add(resource.Value.Id,
                        new GameResourceModel(_data.CollectionOfGameResources[resource.Value.Id]));
                }
            }
            else
            {
                InitializeData();

                foreach (var resource in _configs.CollectionOfGameResources)
                {
                    CollectionOfGameResourceModels.Add(resource.Value.Id,
                        new GameResourceModel(_data.CollectionOfGameResources[resource.Value.Id]));
                }
            }
        }

        private void InitializeData()
        {
            foreach (var config in _configs.CollectionOfGameResources)
            {
                _data.CollectionOfGameResources.Add(config.Value.Id, new GameResourceData());
                _data.CollectionOfGameResources[config.Value.Id].Amount = config.Value.StartAmount;
                _data.CollectionOfGameResources[config.Value.Id].Id = config.Value.Id;
            }

            _data.IsInitialized = true;
        }
    }
}