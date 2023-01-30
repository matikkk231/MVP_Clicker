using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Game.Areas.SaveSystem;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;
using Project.Scripts.Game.Base.GameModels;
using Project.Scripts.Game.Base.GamePresenters;
using Project.Scripts.Game.Base.GameViews;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game
{
    public class EntryPoint : MonoBehaviour
    {
        private GameViews _views;

        private GameModels _models;

        private GamePresenter _presenters;

        private GameConfigs _configs;

        private IGameData _data;

        private ISaveSystemService _saveSystem;
        private ILoadResourcesService _loadResourcesService;

        [Inject]
        private void Constructor(ILoadResourcesService loadResourcesService, ISaveSystemService saveSystemService)
        {
            _loadResourcesService = loadResourcesService;
            _saveSystem = saveSystemService;
        }

        private async void Start()
        {
            _views = new GameViews(_loadResourcesService);
            _configs = new GameConfigs(_loadResourcesService);
            await _configs.LoadAsync();
            await _views.LoadAsync();
            _data = _saveSystem.LoadData<GameData>();
            if (_data == null)
            {
                _data = new GameData();
                _models = new GameModels(_data, _configs);
                _presenters = new GamePresenter(_models, _views, _configs);
            }
            else
            {
                _models = new GameModels(_data, _configs);
                _presenters = new GamePresenter(_models, _views, _configs);
            }
        }

        private void OnDestroy()
        {
            _saveSystem.SaveData(_data);
            _configs.Dispose();
            _presenters.Dispose();
            _models.Dispose();
        }
    }
}