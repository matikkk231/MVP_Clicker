using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResourcesId;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public class BonusesShopModel : IBonusesShopModel, IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IGameResourcesId _gameResourcesId;
        private readonly Dictionary<string, IBonusModel> _collection = new();

        public Dictionary<string, IBonusModel> Collection => _collection;

        public BonusesShopModel(IGameResourcesModel gameResources,
            IBonusesShopConfig configs, IGameResourcesId gameResourcesId)
        {
            _gameResources = gameResources;
            _gameResourcesId = gameResourcesId;

            _collection.Add(configs.Sword.Id, new BonusModel(configs.Sword));
            UpdateDamagePerTapBonus(CalculateDamagePerTapBonusFromAllBonuses(_collection));

            AddListeners();
        }

        public BonusesShopModel(IGameResourcesModel gameResources,
            IBonusesShopData bonusesShopData, IGameResourcesId gameResourcesId)
        {
            _gameResources = gameResources;
            _gameResourcesId = gameResourcesId;

            _collection.Add(bonusesShopData.Sword.Id, new BonusModel(bonusesShopData.Sword));

            AddListeners();
        }

        private void OnUpgradeBought(string upgradedBonus)
        {
            bool isMoneyEnoughForUpgrade = _gameResources.Collection[_gameResourcesId.Money].Amount >=
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
            _gameResources.Collection[_gameResourcesId.Money].Amount -= _collection[upgradedBonus].UpgradeValue;
        }

        private void UpdateDamagePerTapBonus(int increaseDamagePerTapBonus)
        {
            _gameResources.Collection[_gameResourcesId.DamagePerTap].Amount += increaseDamagePerTapBonus;
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