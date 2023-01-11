using System;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IDisposable, IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        public MonsterLogicHandlerModel MonsterLogicHandler { get; }
        public ILevelSystemModel LevelSystem { get; }
        public IBonusesShopModel BonusesShop { get; }


        public MainMenuModel(IGameData data, IGameConfigs configs)
        {
            GameResources = new GameResourcesModel(data.GameResources, configs.GameResourcesConfig);
            Monster = new MonsterModel(data.Monster, configs.MonsterConfig);
            LevelSystem = new LevelSystemModel(data.LevelSystem);
            BonusesShop = new BonusesShopModel(GameResources, data.BonusesShop, configs);
            MonsterLogicHandler =
                new MonsterLogicHandlerModel(GameResources, Monster, LevelSystem, configs.GameResourcesConfig);
        }

        public void Dispose()
        {
            MonsterLogicHandler.Dispose();
        }
    }
}