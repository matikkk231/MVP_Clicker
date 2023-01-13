using System;
using Project.Scripts.Game.Areas.Bonus.Config;
using Project.Scripts.Game.Areas.Bonus.Model;
using Project.Scripts.Game.Areas.Bonus.View;

namespace Project.Scripts.Game.Areas.Bonus.Presenter
{
    public class BonusPresenter : IDisposable
    {
        private readonly IBonusView _view;
        private readonly IBonusModel _model;

        public BonusPresenter(IBonusView view, IBonusModel model, IBonusConfig config)
        {
            _view = view;
            _model = model;
            _view.SetBonusSprite(config.BonusSprite);
            AddListeners();
            OnUpdated();
        }

        private void OnUpdated()
        {
            _view.SetBonusLevel(_model.BonusLevel);
            _view.SetProvidingBonus(_model.ProvidingBonus);
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