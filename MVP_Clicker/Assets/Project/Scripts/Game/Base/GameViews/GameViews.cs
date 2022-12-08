using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.CameraView;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews: MonoBehaviour, IGameViews
    {
        [SerializeField] private CameraView _cameraPrefab;
        
        public IViewCreate<ICameraView> Camera => new ViewCreate<CameraView>(_cameraPrefab);
    }
}