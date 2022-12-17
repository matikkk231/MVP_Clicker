using System;
using Project.Scripts.Game.Areas.Bonus.Presenter;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.BonusesShop.View;

namespace Project.Scripts.Game.Areas.BonusesShop.Presenter
{
    public class BonusesShopPresenter : IDisposable
    {
        private readonly BonusPresenter _sword;
        public BonusesShopPresenter(IBonusesShopView bonusesShopView, IBonusesShopModel bonusesShopModel)
        {
            _sword = new BonusPresenter(bonusesShopView.SwordBonus, bonusesShopModel.SwordBonus);
        }

        public void Dispose()
        {
            _sword.Dispose();
        }
    }
}