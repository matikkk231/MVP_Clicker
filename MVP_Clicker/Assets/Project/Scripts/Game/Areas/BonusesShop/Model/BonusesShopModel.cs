using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.BonusId.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResourcesId.Model;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public class BonusesShopModel : IBonusesShopModel, IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IGameResourcesId _gameResourcesId;
        private readonly Dictionary<string, IBonusModel> _collection = new();
        private readonly IBonusId _bonusId;

        public Dictionary<string, IBonusModel> Collection => _collection;

        public BonusesShopModel(IGameResourcesModel gameResources, IGameResourcesId gameResourcesId)
        {
            _gameResources = gameResources;
            _gameResourcesId = gameResourcesId;
            _bonusId = new BonusId.Model.BonusId();

            _collection.Add(_bonusId.Sword, new BonusModel(_bonusId.Sword));

            AddListeners();
        }

        private void OnUpgradeBought(string upgradedBonus)
        {
            bool isMoneyEnoughForUpgrade = _gameResources.Collection[_gameResourcesId.Money].Amount >=
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
            _gameResources.Collection[_gameResourcesId.Money].Amount -= _collection[upgradedBonus].UpgradeValue;
        }

        private void UpdateDamagePerTapBonus()
        {
            int sumDamagePerTapBonusFromAllBonuses = _collection[_bonusId.Sword].ProvidingDamagePerTapBonus;
            int receivedDamagePerTapBonus = sumDamagePerTapBonusFromAllBonuses;
            _gameResources.Collection[_gameResourcesId.DamagePerTap].Amount = receivedDamagePerTapBonus;
        }

        private void AddListeners()
        {
            _collection[_bonusId.Sword].UpgradeBought += OnUpgradeBought;
            _collection[_bonusId.Sword].DamagePerTapBonusChanged += UpdateDamagePerTapBonus;
        }

        private void RemoveListeners()
        {
            _collection[_bonusId.Sword].UpgradeBought -= OnUpgradeBought;
            _collection[_bonusId.Sword].DamagePerTapBonusChanged -= UpdateDamagePerTapBonus;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}