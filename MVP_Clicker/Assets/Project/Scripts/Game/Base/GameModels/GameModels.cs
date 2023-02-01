using System;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.MainMenu.Model;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels : IDisposable, IGameModels
    {
        public ICameraModel Camera { get; }
        public IMainMenuModel MainMenu { get; }
        public GameModels(IGameData data, IGameConfigs configs, ICoroutineStarterService coroutineStarterService)
        {
            Camera = new CameraModel();
            MainMenu = new MainMenuModel(data, configs, coroutineStarterService);
        }

        public void Dispose()
        {
            MainMenu.MonsterLogicHandler.Dispose();
        }
    }
}