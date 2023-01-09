using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        public Dictionary<string, IGameResourceModel> Collection { get; } = new();


        public GameResourcesModel(IGameResourcesConfig gameResourcesConfig)
        {
            IGameResourceModel money =
                new GameResourceModel(gameResourcesConfig.Money.Id, gameResourcesConfig.Money.StartAmount);
            Collection.Add(money.Id, money);

            IGameResourceModel damagePerTap = new GameResourceModel(gameResourcesConfig.DamagePerTap.Id,
                gameResourcesConfig.DamagePerTap.StartAmount);
            Collection.Add(damagePerTap.Id, damagePerTap);
        }

        public GameResourcesModel(IGameResourcesData data)
        {
            IGameResourceModel money =
                new GameResourceModel(data.Money.Id, data.Money.Amount);
            Collection[money.Id] = money;

            IGameResourceModel damagePerTap = new GameResourceModel(data.DamagePerTap.Id,
                data.DamagePerTap.Amount);
            Collection[damagePerTap.Id] = damagePerTap;
        }
    }
}