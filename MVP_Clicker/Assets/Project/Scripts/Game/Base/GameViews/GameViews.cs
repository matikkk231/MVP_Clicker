using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.CameraView;
using Project.Scripts.Game.Areas.Views.Canvas;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews: MonoBehaviour, IGameViews
    {
        [SerializeField] private CameraView _cameraPrefab;
        [SerializeField] private CanvasView _canvasPrefab;
        
        public IViewCreate<ICameraView> CameraView => new ViewCreate<CameraView>(_cameraPrefab);
        public IViewCreate<ICanvasView> CanvasView => new ViewCreate<CanvasView>(_canvasPrefab);
    }
}