using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        private readonly Dictionary<string, IGameResourceModel> _resources = new();

        public Dictionary<string, IGameResourceModel> GameResources
        {
            get => _resources;
        }

        public GameResourcesModel()
        {
            int startAmountOfMoney = 0;
            IGameResourceModel money = new GameResourceModel("money", startAmountOfMoney);
            _resources.Add(money.ID, money);
        }
    }
}