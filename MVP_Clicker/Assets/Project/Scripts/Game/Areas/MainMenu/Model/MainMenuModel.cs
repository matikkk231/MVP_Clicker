using System;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IDisposable, IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        public MonsterLogicHandlerModel MonsterLogicHandlerModel { get; }
        public ILevelSystemModel LevelSystem { get; }


        public MainMenuModel()
        {
            GameResources = new GameResourcesModel();

            const int startMonsterHp = 3;
            const int startRewardForKilling = 1;
            Monster = new MonsterModel(startMonsterHp, startRewardForKilling);

            LevelSystem = new LevelSystemModel();
            MonsterLogicHandlerModel = new MonsterLogicHandlerModel(GameResources, Monster, LevelSystem);
        }

        public void Dispose()
        {
            MonsterLogicHandlerModel.Dispose();
        }
    }
}