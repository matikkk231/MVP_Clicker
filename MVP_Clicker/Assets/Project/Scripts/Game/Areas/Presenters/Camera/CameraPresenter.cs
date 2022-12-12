using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Models.Camera;
using Project.Scripts.Game.Areas.Views.CameraView;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class CameraPresenter : ICameraPresenter, IDisposable
    {
        private readonly ICameraModel _cameraModel;
        private readonly IViewBox<ICameraView> _cameraViewBox;

        public ICameraModel CameraModel { get; }
        public ICameraView CameraView { get; }

        public CameraPresenter(IViewCreate<ICameraView> cameraView, ICameraModel cameraModel)
        {
            _cameraModel = cameraModel;
            _cameraViewBox = cameraView.CreateObject();

            AddListeners();
        }

        private void OnUpdated()
        {
            _cameraViewBox.GetView.SetPosition(_cameraModel.Position);
        }

        private void AddListeners()
        {
            _cameraModel.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _cameraModel.Updated -= OnUpdated;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}