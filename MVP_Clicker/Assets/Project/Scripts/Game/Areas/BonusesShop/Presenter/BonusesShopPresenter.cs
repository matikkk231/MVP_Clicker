using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.Presenter;
using Project.Scripts.Game.Areas.Bonus.View;
using Project.Scripts.Game.Areas.BonusesShop.Config;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.BonusesShop.View;

namespace Project.Scripts.Game.Areas.BonusesShop.Presenter
{
    public class BonusesShopPresenter : IDisposable
    {
        private readonly Dictionary<string, IDisposable> _bonusPresenters = new();

        public BonusesShopPresenter(IBonusesShopView bonusesShopView, IBonusesShopModel bonusesShopModel,
            IBonusesShopConfig configs)
        {
            bonusesShopView.CollectionOfBonuses = new Dictionary<string, IBonusView>();
            foreach (var config in configs.CollectionOfBonuses)
            {
                bonusesShopView.CollectionOfBonuses.Add(config.Value.Id, bonusesShopView.CreateBonusView());

                _bonusPresenters.Add(config.Value.Id,
                    new BonusPresenter(bonusesShopView.CollectionOfBonuses[config.Value.Id],
                        bonusesShopModel.Collection[config.Value.Id], config.Value));
            }
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