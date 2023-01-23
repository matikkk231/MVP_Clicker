using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;
using Project.Scripts.Game.Areas.SaveSystem;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;
using Project.Scripts.Game.Base.GameModels;
using Project.Scripts.Game.Base.GamePresenters;
using Project.Scripts.Game.Base.GameViews;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameViews _views;

        private GameModels _models;

        private GamePresenter _presenters;

        private GameConfigs _configs;

        private IGameData _data;

        private ISaveSystemService _saveSystem;


        private void Start()
        {
            _saveSystem = new SaveSystemService();
            _configs = new GameConfigs(new LoadResourcesService());
            _data = _saveSystem.LoadData();
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