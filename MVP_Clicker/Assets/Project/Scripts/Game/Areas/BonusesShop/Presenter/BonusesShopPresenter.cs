using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Presenter;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.BonusesShop.View;

namespace Project.Scripts.Game.Areas.BonusesShop.Presenter
{
    public class BonusesShopPresenter : IDisposable
    {
        private readonly Dictionary<string, IDisposable> _bonusPresenters = new();

        public BonusesShopPresenter(IBonusesShopView bonusesShopView, IBonusesShopModel bonusesShopModel)
        {
            var bonusId = new BonusId.Model.BonusId();
            _bonusPresenters.Add(bonusId.Sword,
                new BonusPresenter(bonusesShopView.Sword, bonusesShopModel.Collection[bonusId.Sword]));
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