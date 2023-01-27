using System.Threading.Tasks;
using Project.Scripts.Core;
using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Camera.View;
using Project.Scripts.Game.Areas.MainMenu.View;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews : IGameViews, ILoadable
    {
        private CameraView _cameraPrefab;
        private MainMenuView _mainMenuPrefab;
        private readonly ILoadResourcesService _loadResourcesService;

        public IViewCreator<ICameraView> Camera => new ViewCreator<CameraView>(_cameraPrefab);
        public IViewCreator<IMainMenuView> MainMenu => new ViewCreator<MainMenuView>(_mainMenuPrefab);

        public GameViews(ILoadResourcesService loadResourcesService)
        {
            _loadResourcesService = loadResourcesService;
        }

        public Task LoadAsync()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                var cameraObject = _loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainCamera.prefab");
                _cameraPrefab = cameraObject.ConvertTo<CameraView>();
                var mainMenuObject = _loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainMenu.prefab");
                _mainMenuPrefab = mainMenuObject.ConvertTo<MainMenuView>();
            });
            return task;
        }
    }
}