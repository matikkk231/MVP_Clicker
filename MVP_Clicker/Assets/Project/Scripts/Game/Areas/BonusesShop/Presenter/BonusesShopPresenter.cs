using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Presenter;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.BonusesShop.View;

namespace Project.Scripts.Game.Areas.BonusesShop.Presenter
{
    public class BonusesShopPresenter : IDisposable
    {
        private readonly Dictionary<string, IDisposable> _bonusPresenters = new();

        public BonusesShopPresenter(IBonusesShopView bonusesShopView, IBonusesShopModel bonusesShopModel,
            IBonusesShopConfig config)
        {
            _bonusPresenters.Add(config.Sword.Id,
                new BonusPresenter(bonusesShopView.Sword, bonusesShopModel.Collection[config.Sword.Id]));
        }

        public BonusesShopPresenter(IBonusesShopView bonusesShopView, IBonusesShopModel bonusesShopModel,
            IBonusesShopData data)
        {
            _bonusPresenters.Add(data.Sword.Id,
                new BonusPresenter(bonusesShopView.Sword, bonusesShopModel.Collection[data.Sword.Id]));
        }

        public void Dispose()
        {
            foreach (var presenter in _bonusPresenters.Values)
            {
                presenter.Dispose();
            }
        }
    }
}