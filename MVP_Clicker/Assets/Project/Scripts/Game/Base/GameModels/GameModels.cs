using Project.Scripts.Game.Areas.Models.CameraModel;
using Project.Scripts.Game.Areas.Models.Canvas;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels: IGameModels
    {
        public ICameraModel CameraModel { get; }
        public ICanvasModel CanvasModel { get; }

        public GameModels()
        {
            CameraModel = new CameraModel();
            CanvasModel = new CanvasModel();
        }
    }
}