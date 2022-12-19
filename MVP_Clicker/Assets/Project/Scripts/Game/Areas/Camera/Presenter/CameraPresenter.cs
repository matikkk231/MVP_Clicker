using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Camera.View;

namespace Project.Scripts.Game.Areas.Camera.Presenter
{
    public class CameraPresenter : IDisposable
    {
        private readonly IBoxView<ICameraView> _boxViewWithCamera;
        private readonly ICameraModel _cameraModel;

        public CameraPresenter(IViewCreator<ICameraView> viewCreator, ICameraModel model)
        {
            _boxViewWithCamera = viewCreator.CreateObject();
            _cameraModel = model;
            AddListeners();
        }

        private void AddListeners()
        {
            _cameraModel.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _cameraModel.Updated -= OnUpdated;
        }

        private void OnUpdated()
        {
            _boxViewWithCamera.View.SetPosition(_cameraModel.Position);
        }
        
        public void Dispose()
        {
            RemoveListeners();
            _boxViewWithCamera.Destroy();
        }
    }
}