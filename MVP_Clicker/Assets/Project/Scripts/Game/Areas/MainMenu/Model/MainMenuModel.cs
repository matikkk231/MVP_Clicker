using System;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IDisposable, IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        public MonsterLogicHandlerModel MonsterLogicHandler { get; }
        public ILevelSystemModel LevelSystem { get; }
        public IBonusesShopModel BonusesShop { get; }

        public MainMenuModel()
        {
            GameResources = new GameResourcesModel();
            var gameResourcesId = new GameResourcesId.Model.GameResourcesId();

            const int startMonsterHp = 3;
            const int startRewardForKilling = 1;
            Monster = new MonsterModel(startMonsterHp, startRewardForKilling);

            LevelSystem = new LevelSystemModel();
            MonsterLogicHandler = new MonsterLogicHandlerModel(GameResources, Monster, LevelSystem);

            BonusesShop = new BonusesShopModel(GameResources, gameResourcesId);
        }

        public void Dispose()
        {
            MonsterLogicHandler.Dispose();
        }
    }
}