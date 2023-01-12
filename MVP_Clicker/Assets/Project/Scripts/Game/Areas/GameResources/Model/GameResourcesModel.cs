using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        private readonly IGameResourcesData _data;
        private readonly IGameResourcesConfig _config;
        public Dictionary<string, IGameResourceModel> Collection { get; } = new();


        public GameResourcesModel(IGameResourcesData data, IGameResourcesConfig config)
        {
            _data = data;
            _config = config;
            if (_data.IsInitialized)
            {
                IGameResourceModel money =
                    new GameResourceModel(_data.Money);
                Collection[money.Id] = money;

                IGameResourceModel damagePerTap = new GameResourceModel(_data.DamagePerTap);
                Collection[damagePerTap.Id] = damagePerTap;

                // foreach (var id in config.Dictionarh.Keys)
                // {
                //     var specificConfig = config.Dictionary[id];
                //     var specificData = data.Dictionarh[id];
                //     var model = new GameResourceModel(specificConfig, specificData);
                //     
                //     Collection[id] = model;
                // }
            }
            else
            {
                InitializeData();

                IGameResourceModel money =
                    new GameResourceModel(_data.Money);
                Collection[money.Id] = money;

                IGameResourceModel damagePerTap = new GameResourceModel(_data.DamagePerTap);
                Collection[damagePerTap.Id] = damagePerTap;
            }
        }

        private void InitializeData()
        {
            _data.Money.Amount = _config.Money.StartAmount;
            _data.Money.Id = _config.Money.Id;

            _data.DamagePerTap.Amount = _config.DamagePerTap.StartAmount;
            _data.DamagePerTap.Id = _config.DamagePerTap.Id;

            _data.IsInitialized = true;
        }
    }
}