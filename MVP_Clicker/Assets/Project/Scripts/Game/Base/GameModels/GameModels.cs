using System;
using Project.Scripts.Game.Areas.MainMenu.Model;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels : IDisposable, IGameModels
    {
        public ICameraModel Camera { get; }
        public IMainMenuModel MainMenu { get; }

        public GameModels()
        {
            Camera = new CameraModel();
            MainMenu = new MainMenuModel();
        }

        public void Dispose()
        {
            MainMenu.MonsterLogicHandlerModel.Dispose();
        }
    }
}