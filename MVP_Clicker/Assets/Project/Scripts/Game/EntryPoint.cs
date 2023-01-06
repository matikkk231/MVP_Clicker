using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Base.GameConfigs;
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


        private void Start()
        {
            var bonusesShopScriptableObject = Resources.Load("BonusesShop");
            var bonusesShopConfig = bonusesShopScriptableObject.ConvertTo<BonusesShopConfig>();
            _configs = new GameConfigs(bonusesShopConfig);

            _models = new GameModels(_configs);
            _presenters = new GamePresenter(_models, _views);
        }

        private void OnDestroy()
        {
            _presenters.Dispose();
            _models.Dispose();
        }
        
    }
}