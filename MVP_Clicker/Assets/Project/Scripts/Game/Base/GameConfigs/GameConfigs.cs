using System;
using System.Threading.Tasks;
using Project.Scripts.Core;
using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Game.Areas.Achievements.Config;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Base.GameConfigs
{
    public class GameConfigs : IGameConfigs, IDisposable, ILoadable
    {
        private readonly ILoadResourcesService _loadResourcesService;

        public IBonusesShopConfig BonusesShopConfig { get; private set; }
        public IGameResourcesConfig GameResourcesConfig { get; private set; }
        public IMonsterConfig MonsterConfig { get; private set; }
        public IAchievementsConfig Achievements { get; private set; }

        public GameConfigs(ILoadResourcesService loadResourcesService)
        {
            _loadResourcesService = loadResourcesService;
        }

        public void Dispose()
        {
            _loadResourcesService.Unload("Bonuses/BonusesShop");
            _loadResourcesService.Unload("GameResourcesCollection");
            _loadResourcesService.Unload("Monsters/BigStone");
            _loadResourcesService.Unload("Assets/Project/Configs/Achievements/CollectionOfAchievements.asset");
        }

        public async Task LoadAsync()
        {
            var bonusesShopScriptableObject = await _loadResourcesService.Load<Object>("Bonuses/BonusesShop");
            var bonusesShopConfig = bonusesShopScriptableObject.ConvertTo<BonusesShopConfig>();
            var gameResourcesScriptableObject = await
                _loadResourcesService.Load<Object>("GameResourcesCollection");
            var gameResourcesConfig = gameResourcesScriptableObject.ConvertTo<GameResourcesConfig>();
            var monsterScriptableObject = await _loadResourcesService.Load<Object>("Monsters/BigStone");
            var monsterConfig = monsterScriptableObject.ConvertTo<MonsterConfig>();
            var achievementsObject =
                await _loadResourcesService.Load<Object>(
                    "Assets/Project/Configs/Achievements/CollectionOfAchievements.asset");
            Achievements = achievementsObject.ConvertTo<IAchievementsConfig>();

            BonusesShopConfig = bonusesShopConfig;
            GameResourcesConfig = gameResourcesConfig;
            MonsterConfig = monsterConfig;
        }
    }
}