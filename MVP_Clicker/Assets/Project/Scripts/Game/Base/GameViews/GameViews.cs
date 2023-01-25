using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Camera.View;
using Project.Scripts.Game.Areas.MainMenu.View;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews : IGameViews
    {
        private readonly CameraView _cameraPrefab;
        private readonly MainMenuView _mainMenuPrefab;

        public IViewCreator<ICameraView> Camera => new ViewCreator<CameraView>(_cameraPrefab);
        public IViewCreator<IMainMenuView> MainMenu => new ViewCreator<MainMenuView>(_mainMenuPrefab);

        public GameViews(ILoadResourcesService loadResourcesService)
        {
            var cameraObject = loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainCamera.prefab");
            _cameraPrefab = cameraObject.ConvertTo<CameraView>();
            var mainMenuObject = loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainMenu.prefab");
            _mainMenuPrefab = mainMenuObject.ConvertTo<MainMenuView>();
        }
    }
}