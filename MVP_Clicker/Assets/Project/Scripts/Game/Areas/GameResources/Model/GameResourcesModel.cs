using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResourcesId.Model;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        public Dictionary<string, IGameResourceModel> Collection { get; } = new();

        public IGameResourcesId Id { get; }

        public GameResourcesModel()
        {
            Id = new GameResourcesId.Model.GameResourcesId();

            int startAmountOfMoney = 0;
            IGameResourceModel money = new GameResourceModel(Id.Money, startAmountOfMoney);
            Collection.Add(Id.Money, money);

            int startAmountOfDamagePerTap = 1;
            IGameResourceModel damagePerTap = new GameResourceModel(Id.DamagePerTap, startAmountOfDamagePerTap);
            Collection.Add(damagePerTap.ID, damagePerTap);
        }
    }
}