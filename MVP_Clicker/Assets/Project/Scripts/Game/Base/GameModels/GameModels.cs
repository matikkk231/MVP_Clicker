using Project.Scripts.Game.Areas.Models.CameraModel;

namespace Project.Scripts.Game.Base.GameModels
{
    public class GameModels: IGameModels
    {
        public ICameraModel CameraModel { get; }

        public GameModels()
        {
            CameraModel = new CameraModel();
        }
    }
}