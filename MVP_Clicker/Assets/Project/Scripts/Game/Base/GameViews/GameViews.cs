using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Camera.View;
using Project.Scripts.Game.Areas.MainMenu.View;
using UnityEngine;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews : MonoBehaviour, IGameViews
    {
        [SerializeField] private CameraView _cameraPrefab;
        [SerializeField] private MainMenuView _mainMenuPrefab;


        public IViewCreator<ICameraView> Camera => new ViewCreator<CameraView>(_cameraPrefab);
        public IViewCreator<IMainMenuView> MainMenu => new ViewCreator<MainMenuView>(_mainMenuPrefab);

    }
}