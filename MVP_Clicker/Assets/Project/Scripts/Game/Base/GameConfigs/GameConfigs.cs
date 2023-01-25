using System;
using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public class GameConfigs : IGameConfigs, IDisposable
    {
        private readonly ILoadResourcesService _loadResourcesService;
        
        public IBonusesShopConfig BonusesShopConfig { get; }
        public IGameResourcesConfig GameResourcesConfig { get; }
        public IMonsterConfig MonsterConfig { get; }

        public GameConfigs(ILoadResourcesService loadResourcesService)
        {
            _loadResourcesService = loadResourcesService;
            
            var bonusesShopScriptableObject = loadResourcesService.Load<Object>("Bonuses/BonusesShop");
            var bonusesShopConfig = bonusesShopScriptableObject.ConvertTo<BonusesShopConfig>();
            var gameResourcesScriptableObject =
                loadResourcesService.Load<Object>("GameResourcesCollection");
            var gameResourcesConfig = gameResourcesScriptableObject.ConvertTo<GameResourcesConfig>();
            var monsterScriptableObject = loadResourcesService.Load<Object>("Monsters/BigStone");
            var monsterConfig = monsterScriptableObject.ConvertTo<MonsterConfig>();

            BonusesShopConfig = bonusesShopConfig;
            GameResourcesConfig = gameResourcesConfig;
            MonsterConfig = monsterConfig;
        }

        public void Dispose()
        {
            _loadResourcesService.Unload("Bonuses/BonusesShop");
            _loadResourcesService.Unload("GameResourcesCollection");
            _loadResourcesService.Unload("Monsters/BigStone");
        }
    }
}