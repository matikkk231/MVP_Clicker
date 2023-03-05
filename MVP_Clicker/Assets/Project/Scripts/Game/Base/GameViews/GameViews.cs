using System;
using System.Threading.Tasks;
using Project.Scripts.Core;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Achievements.View;
using Project.Scripts.Game.Areas.Camera.View;
using Project.Scripts.Game.Areas.MainMenu.View;
using Unity.VisualScripting;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Base.GameViews
{
    public class GameViews : IGameViews, ILoadable, IDisposable
    {
        private CameraView _cameraPrefab;
        private MainMenuView _mainMenuPrefab;
        private AchievementsView _achievementsMenuPrefab;
        private CoroutineStarterService _coroutineStarterService;
        private readonly ILoadResourcesService _loadResourcesService;

        public IViewCreator<ICameraView> Camera => new ViewCreator<CameraView>(_cameraPrefab);
        public IViewCreator<IMainMenuView> MainMenu => new ViewCreator<MainMenuView>(_mainMenuPrefab);

        public IViewCreator<CoroutineStarterService> CoroutineStarter =>
            new ViewCreator<CoroutineStarterService>(_coroutineStarterService);

        public IViewCreator<AchievementsView> Achievements =>
            new ViewCreator<AchievementsView>(_achievementsMenuPrefab);

        public GameViews(ILoadResourcesService loadResourcesService)
        {
            _loadResourcesService = loadResourcesService;
        }

        public async Task LoadAsync()
        {
            var cameraObject = await _loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainCamera.prefab");
            _cameraPrefab = cameraObject.ConvertTo<CameraView>();
            var mainMenuObject = await _loadResourcesService.Load<Object>("Assets/Project/Prefabs/MainMenu.prefab");
            _mainMenuPrefab = mainMenuObject.ConvertTo<MainMenuView>();
            var coroutineStarterServiceObject =
                await _loadResourcesService.Load<Object>("Assets/Project/Prefabs/CoroutineStarterService.prefab");
            _coroutineStarterService = coroutineStarterServiceObject.ConvertTo<CoroutineStarterService>();
        }

        public void Dispose()
        {
            _loadResourcesService.Unload("Assets/Project/Prefabs/MainCamera.prefab");
            _loadResourcesService.Unload("Assets/Project/Prefabs/MainMenu.prefab");
            _loadResourcesService.Unload("Assets/Project/Prefabs/CoroutineStarterService.prefab");
        }
    }
}