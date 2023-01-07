using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.Monster.Config;
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
            _configs = LoadGameConfigs();
            _models = new GameModels(_configs);
            _presenters = new GamePresenter(_models, _views, _configs);
        }

        private GameConfigs LoadGameConfigs()
        {
            var bonusesShopScriptableObject = Resources.Load("Bonuses/BonusesShop");
            var bonusesShopConfig = bonusesShopScriptableObject.ConvertTo<BonusesShopConfig>();
            var gameResourcesScriptableObject = Resources.Load("GameResources/GameResourcesCollection");
            var gameResourcesConfig = gameResourcesScriptableObject.ConvertTo<GameResourcesConfig>();
            var monsterScriptableObject = Resources.Load("Monsters/BigStone");
            var monsterConfig = monsterScriptableObject.ConvertTo<MonsterConfig>();

            return new GameConfigs(bonusesShopConfig, gameResourcesConfig, monsterConfig);
        }

        private void OnDestroy()
        {
            _presenters.Dispose();
            _models.Dispose();
        }
    }
}