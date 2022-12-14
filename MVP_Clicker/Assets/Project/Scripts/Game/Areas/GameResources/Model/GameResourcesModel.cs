using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResourcesId.Model;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.GameResources.Model
{
    public class GameResourcesModel : IGameResourcesModel
    {
        private readonly Dictionary<string, IGameResourceModel> _gameResources = new();
        private readonly IGameResourcesId _id;

        public Dictionary<string, IGameResourceModel> Collection => _gameResources;
        public IGameResourcesId Id => _id;

        public GameResourcesModel()
        {
            _id = new GameResourcesId.Model.GameResourcesId();
            
            int startAmountOfMoney = 0;
            IGameResourceModel money = new GameResourceModel(Id.Money, startAmountOfMoney);
            _gameResources.Add(Id.Money, money);

            int startAmountOfDamagePerTap = 1;
            IGameResourceModel damagePerTap = new GameResourceModel(Id.DamagePerTap, startAmountOfDamagePerTap);
            _gameResources.Add(damagePerTap.ID, damagePerTap);
        }
    }
}