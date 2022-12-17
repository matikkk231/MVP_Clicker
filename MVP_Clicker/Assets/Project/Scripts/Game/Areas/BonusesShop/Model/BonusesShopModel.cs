using System;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResourcesId.Model;

namespace Project.Scripts.Game.Areas.BonusesShop.Model
{
    public class BonusesShopModel : IBonusesShopModel, IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IGameResourcesId _gameResourcesId;
        public IBonusModel SwordBonus { get; }

        public int ReceivedBonusDamagePerTap { get; set; }

        public BonusesShopModel(IGameResourcesModel gameResources, IGameResourcesId gameResourcesId)
        {
            _gameResources = gameResources;
            _gameResourcesId = gameResourcesId;

            SwordBonus = new BonusModel();
            AddListeners();
        }

        private void OnSwordUpgradeBought()
        {
            if (_gameResources.Collection[_gameResourcesId.Money].Amount >= SwordBonus.UpgradeValue)
            {
                _gameResources.Collection[_gameResourcesId.Money].Amount -= SwordBonus.UpgradeValue;

                SwordBonus.ProvidingDamagePerTapBonus++;
                SwordBonus.UpgradeValue *= 2;
                SwordBonus.BonusLevel++;

                _gameResources.Collection[_gameResourcesId.DamagePerTap].Amount = ReceivedBonusDamagePerTap;
            }
        }

        private void OnDamagePerTapBonusChanged()
        {
            ReceivedBonusDamagePerTap = SwordBonus.ProvidingDamagePerTapBonus;
        }

        private void AddListeners()
        {
            SwordBonus.UpgradeBought += OnSwordUpgradeBought;
            SwordBonus.DamagePerTapBonusChanged += OnDamagePerTapBonusChanged;
        }

        private void RemoveListeners()
        {
            SwordBonus.UpgradeBought -= OnSwordUpgradeBought;
            SwordBonus.DamagePerTapBonusChanged -= OnDamagePerTapBonusChanged;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}