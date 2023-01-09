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


        private void Start()
        {
            _data = SaveSystem.LoadData();
            if (_data == null)
            {
                _configs = LoadGameConfigs();
                _models = new GameModels(_configs);
                _presenters = new GamePresenter(_models, _views, _configs);
                _data = new GameData();
            }
            else
            {
                _models = new GameModels(_data);
                _presenters = new GamePresenter(_models, _views, _data);
            }
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

        private void OverwriteGameData()
        {
            _data.Monster.CurrentHp = _models.MainMenu.Monster.CurrentHp;
            _data.Monster.FullHp = _models.MainMenu.Monster.FullHp;
            _data.Monster.RewardForKilling = _models.MainMenu.Monster.RewardForKilling;


            _data.GameResources.Money.Amount =
                _models.MainMenu.GameResources.Collection[_models.MainMenu.GameResourcesId.Money].Amount;
            _data.GameResources.Money.Id = _models.MainMenu.GameResources
                .Collection[_models.MainMenu.GameResourcesId.Money].Id;

            _data.GameResources.DamagePerTap.Amount = _models.MainMenu.GameResources
                .Collection[_models.MainMenu.GameResourcesId.DamagePerTap].Amount;
            _data.GameResources.DamagePerTap.Id = _models.MainMenu.GameResources
                .Collection[_models.MainMenu.GameResourcesId.DamagePerTap].Id;

            _data.LevelSystem.CurrentExperience = _models.MainMenu.LevelSystem.CurrentExperience;
            _data.LevelSystem.CurrentLevel = _models.MainMenu.LevelSystem.CurrentLevel;
            _data.LevelSystem.ExperienceBeforeLevelUp = _models.MainMenu.LevelSystem.ExperienceBeforeLeveUp;

            _data.BonusesShop.Sword.Id = _models.MainMenu.BonusesShop.Collection[_models.MainMenu.BonusesId.Sword].Id;
            _data.BonusesShop.Sword.BonusLevel =
                _models.MainMenu.BonusesShop.Collection[_models.MainMenu.BonusesId.Sword].BonusLevel;
            _data.BonusesShop.Sword.UpgradeValue = _models.MainMenu.BonusesShop
                .Collection[_models.MainMenu.BonusesId.Sword].UpgradeValue;
            _data.BonusesShop.Sword.ProvidingDamagePerTapBonus = _models.MainMenu.BonusesShop
                .Collection[_models.MainMenu.BonusesId.Sword].ProvidingDamagePerTapBonus;
        }

        private void OnDestroy()
        {
            OverwriteGameData();
            SaveSystem.SaveData(_data);
            _presenters.Dispose();
            _models.Dispose();
        }
    }
}