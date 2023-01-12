using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Data;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Base.GameConfigs;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public class BonusesShopModel : IBonusesShopModel, IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IGameConfigs _configs;
        private readonly IBonusesShopData _data;
        private readonly Dictionary<string, IBonusModel> _collection = new();

        public Dictionary<string, IBonusModel> Collection => _collection;


        public BonusesShopModel(IGameResourcesModel gameResources,
            IBonusesShopData bonusesShopData, IGameConfigs configs)
        {
            _gameResources = gameResources;
            _configs = configs;
            _data = bonusesShopData;
            if (bonusesShopData.IsInitialized)
            {
                foreach (var bonus in _configs.BonusesShopConfig.CollectionOfBonuses)
                {
                    _collection.Add(bonus.Value.Id, new BonusModel(_data.CollectionOfBonuses[bonus.Value.Id]));
                }
            }
            else
            {
                InitializeData();
                foreach (var bonus in _configs.BonusesShopConfig.CollectionOfBonuses)
                {
                    _collection.Add(bonus.Value.Id, new BonusModel(_data.CollectionOfBonuses[bonus.Value.Id]));
                }
            }

            AddListeners();
        }

        private void OnUpgradeBought(string upgradedBonus)
        {
            bool isMoneyEnoughForUpgrade = _gameResources.Collection[_configs.GameResourcesConfig.Money.Id].Amount >=
                                           _collection[upgradedBonus].UpgradeValue;
            if (isMoneyEnoughForUpgrade)
            {
                PayForUpgrade(upgradedBonus);
                int providingDamagePerTapBonusBeforeUpgraded = _collection[upgradedBonus].ProvidingDamagePerTapBonus;
                UpdateBonusInfo(upgradedBonus);
                int providingDamagePerTapBonusAfterUpgraded = _collection[upgradedBonus].ProvidingDamagePerTapBonus;
                int increaseDamagePerTapBonus =
                    providingDamagePerTapBonusAfterUpgraded - providingDamagePerTapBonusBeforeUpgraded;
                UpdateDamagePerTapBonus(increaseDamagePerTapBonus);
            }
        }

        private void UpdateBonusInfo(string upgradedBonus)
        {
            _collection[upgradedBonus].UpdateProvidingBonus();
            _collection[upgradedBonus].UpdateUpgradeValue();
            _collection[upgradedBonus].UpdateBonusLevel();
        }

        private void PayForUpgrade(string upgradedBonus)
        {
            _gameResources.Collection[_configs.GameResourcesConfig.Money.Id].Amount -=
                _collection[upgradedBonus].UpgradeValue;
        }

        private void UpdateDamagePerTapBonus(int increaseDamagePerTapBonus)
        {
            _gameResources.Collection[_configs.GameResourcesConfig.DamagePerTap.Id].Amount += increaseDamagePerTapBonus;
        }

        private void AddListeners()
        {
            foreach (KeyValuePair<string, IBonusModel> bonus in _collection)
            {
                bonus.Value.UpgradeBought += OnUpgradeBought;
                bonus.Value.DamagePerTapBonusChanged += UpdateDamagePerTapBonus;
            }
        }

        private void RemoveListeners()
        {
            foreach (KeyValuePair<string, IBonusModel> bonus in _collection)
            {
                bonus.Value.UpgradeBought -= OnUpgradeBought;
                bonus.Value.DamagePerTapBonusChanged -= UpdateDamagePerTapBonus;
            }
        }

        private void InitializeData()
        {
            foreach (var bonusConfig in _configs.BonusesShopConfig.CollectionOfBonuses)
            {
                _data.CollectionOfBonuses.Add(bonusConfig.Value.Id, new BonusData());
                _data.CollectionOfBonuses[bonusConfig.Value.Id].Id = bonusConfig.Value.Id;
                _data.CollectionOfBonuses[bonusConfig.Value.Id].BonusLevel = bonusConfig.Value.StartBonusLevel;
                _data.CollectionOfBonuses[bonusConfig.Value.Id].UpgradeValue = bonusConfig.Value.StartUpgradeValue;
                _data.CollectionOfBonuses[bonusConfig.Value.Id].ProvidingDamagePerTapBonus =
                    bonusConfig.Value.StartProvidingDamagePerTapBonus;
            }

            _data.IsInitialized = true;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}