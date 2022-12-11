using Project.Scripts.Game.Areas.Models.Camera;
using Project.Scripts.Game.Areas.Models.Canvas;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels : IGameModels
    {
        public ICameraModel CameraModel { get; }
        public IMainMenuModel MainMenuModel { get; }

        public GameModels()
        {
            CameraModel = new CameraModel();
            MainMenuModel = new MainMenuModel();
        }
    }
}