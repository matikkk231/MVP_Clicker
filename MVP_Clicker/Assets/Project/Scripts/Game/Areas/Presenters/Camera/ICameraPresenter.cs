using Project.Scripts.Game.Areas.Models.Camera;
using Project.Scripts.Game.Areas.Views.CameraView;

namespace Project.Scripts.Game.Areas.Presenters
{
    public interface ICameraPresenter
    {
        public ICameraModel CameraModel { get; }
        public ICameraView CameraView { get; }
    }
}