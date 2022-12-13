using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        private readonly Dictionary<string, IGameResourceModel> _resources = new();

        public Dictionary<string, IGameResourceModel> Collection
        {
            get => _resources;
        }

        public GameResourcesModel()
        {
            int startAmountOfMoney = 0;
            IGameResourceModel money = new GameResourceModel("money", startAmountOfMoney);
            _resources.Add(money.ID, money);

            int startAmountOfDamagePerTap = 1;
            IGameResourceModel damagePerTap = new GameResourceModel("damagePerTap", startAmountOfDamagePerTap);
            _resources.Add(damagePerTap.ID, damagePerTap);
        }
    }
}