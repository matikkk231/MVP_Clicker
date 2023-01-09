using System;
using Project.Scripts.Game.Areas.MainMenu.Model;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels : IDisposable, IGameModels
    {
        public ICameraModel Camera { get; }
        public IMainMenuModel MainMenu { get; }

        public GameModels(IGameConfigs configs)
        {
            Camera = new CameraModel();
            MainMenu = new MainMenuModel(configs);
        }

        public GameModels(IGameData data)
        {
            Camera = new CameraModel();
            MainMenu = new MainMenuModel(data);
        }

        public void Dispose()
        {
            MainMenu.MonsterLogicHandler.Dispose();
        }
    }
}