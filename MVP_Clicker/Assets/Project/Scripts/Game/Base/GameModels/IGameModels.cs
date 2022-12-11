using Project.Scripts.Game.Areas.Models.Camera;
using Project.Scripts.Game.Areas.Models.Canvas;

namespace Project.Scripts.Game.Base.GameModels
{
    public interface IGameModels
    {
        public ICameraModel CameraModel { get; }
        public IMainMenuModel MainMenuModel { get; }
    }
}