using System;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResourcesId;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;
using Project.Scripts.Game.BonusesId;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IDisposable, IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        public MonsterLogicHandlerModel MonsterLogicHandler { get; }
        public ILevelSystemModel LevelSystem { get; }
        public IBonusesShopModel BonusesShop { get; }
        public IGameResourcesId GameResourcesId { get; }
        public IBonusesId BonusesId { get; }

        public MainMenuModel(IGameConfigs configs)
        {
            GameResources = new GameResourcesModel(configs.GameResourcesConfig);
            Monster = new MonsterModel(configs.MonsterConfig);
            LevelSystem = new LevelSystemModel();
            GameResourcesId = new GameResourcesId.GameResourcesId(configs.GameResourcesConfig);
            MonsterLogicHandler =
                new MonsterLogicHandlerModel(GameResources, Monster, LevelSystem, GameResourcesId);
            BonusesShop = new BonusesShopModel(GameResources, configs.BonusesShopConfig,
                GameResourcesId);
            BonusesId = new BonusesId.BonusesId(configs.BonusesShopConfig.Sword.Id);
        }

        public MainMenuModel(IGameData data)
        {
            GameResourcesId = new GameResourcesId.GameResourcesId(data.GameResources);
            GameResources = new GameResourcesModel(data.GameResources);
            Monster = new MonsterModel(data.Monster);
            LevelSystem = new LevelSystemModel(data.LevelSystem);
            BonusesShop = new BonusesShopModel(GameResources, data.BonusesShop, GameResourcesId);
            MonsterLogicHandler =
                new MonsterLogicHandlerModel(GameResources, Monster, LevelSystem, GameResourcesId);
            BonusesId = new BonusesId.BonusesId(data.BonusesShop.Sword.Id);
        }

        public void Dispose()
        {
            MonsterLogicHandler.Dispose();
        }
    }
}