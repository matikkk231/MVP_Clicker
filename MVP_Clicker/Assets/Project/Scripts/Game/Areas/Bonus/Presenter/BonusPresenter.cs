using System;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.Bonus.View;

namespace Project.Scripts.Game.Areas.Bonus.Presenter
{
    public class BonusPresenter : IDisposable
    {
        private readonly IBonusView _view;
        private readonly IBonusModel _model;

        public BonusPresenter(IBonusView view, IBonusModel model)
        {
            _view = view;
            _model = model;
            AddListeners();
            OnUpdated();
        }

        private void OnUpdated()
        {
            _view.SetBonusLevel(_model.BonusLevel);
            _view.SetDamagePerTapBonus(_model.ProvidingDamagePerTapBonus);
            _view.SetUpgradeValue(_model.UpgradeValue);
        }

        private void OnBoughtUpgrade()
        {
            _model.BuyUpgrade();
        }

        private void AddListeners()
        {
            _model.Updated += OnUpdated;
            _view.BoughtUpgrade += OnBoughtUpgrade;
        }

        private void RemoveListeners()
        {
            _model.Updated -= OnUpdated;
            _view.BoughtUpgrade -= OnBoughtUpgrade;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}