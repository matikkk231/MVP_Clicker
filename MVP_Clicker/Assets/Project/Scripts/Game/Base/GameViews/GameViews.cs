using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.CameraView;
using Project.Scripts.Game.Areas.Views.Canvas;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews : MonoBehaviour, IGameViews
    {
        [SerializeField] private CameraView _cameraPrefab;
        [SerializeField] private MainMenuView mainMenuPrefab;

        public IViewCreate<ICameraView> CameraView => new ViewCreate<CameraView>(_cameraPrefab);
        public IViewCreate<IMainMenuView> CanvasView => new ViewCreate<MainMenuView>(mainMenuPrefab);
    }
}