using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Model;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public class BonusesShopModel : IBonusesShopModel, IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IGameResourcesConfig _gameResourcesConfig;
        private readonly Dictionary<string, IBonusModel> _collection = new();

        public Dictionary<string, IBonusModel> Collection => _collection;

        public BonusesShopModel(IGameResourcesModel gameResources,
            IBonusesShopConfig configs, IGameResourcesConfig gameResourcesConfig)
        {
            _gameResources = gameResources;
            _gameResourcesConfig = gameResourcesConfig;


            _collection.Add(configs.Sword.Id, new BonusModel(configs.Sword));
            UpdateDamagePerTapBonus();

            AddListeners();
        }

        private void OnUpgradeBought(string upgradedBonus)
        {
            bool isMoneyEnoughForUpgrade = _gameResources.Collection[_gameResourcesConfig.Money.Id].Amount >=
                                           _collection[upgradedBonus].UpgradeValue;
            if (isMoneyEnoughForUpgrade)
            {
                PayForUpgrade(upgradedBonus);
                UpdateBonusInfo(upgradedBonus);
                UpdateDamagePerTapBonus();
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
            _gameResources.Collection[_gameResourcesConfig.Money.Id].Amount -= _collection[upgradedBonus].UpgradeValue;
        }

        private void UpdateDamagePerTapBonus()
        {
            int sumDamagePerTapBonusFromAllBonuses = CalculateDamagePerTapBonusFromAllBonuses(_collection);
            int receivedDamagePerTapBonus = sumDamagePerTapBonusFromAllBonuses;
            _gameResources.Collection[_gameResourcesConfig.DamagePerTap.Id].Amount = receivedDamagePerTapBonus;
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

        private int CalculateDamagePerTapBonusFromAllBonuses(Dictionary<string, IBonusModel> bonuses)
        {
            int sumOfDamagePerTap = 0;
            foreach (KeyValuePair<string, IBonusModel> bonus in bonuses)
            {
                sumOfDamagePerTap += bonus.Value.ProvidingDamagePerTapBonus;
            }

            return sumOfDamagePerTap;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}