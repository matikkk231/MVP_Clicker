using System;
using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class MoneyPresenter : IGameResourcesPresenter, IDisposable
    {
        private IGameResourcesView _moneyView;
        private IGameResourcesModel _moneyModel;

        public IGameResourcesModel GetGameResourcesModel
        {
            get => _moneyModel;
        }

        public IGameResourcesView GetGameResourcesView
        {
            get => _moneyView;
        }

        public MoneyPresenter(IGameResourcesView moneyView, IGameResourcesModel model)
        {
            _moneyView = moneyView;
            _moneyModel = model;
            AddListeners();
            moneyView.SetAmountOfResources(_moneyModel.AmountOfResourseType);
        }

        private void RemoveListeners()
        {
            _moneyModel.Updated -= OnUpdated;
        }

        private void AddListeners()
        {
            _moneyModel.Updated += OnUpdated;
        }

        private void OnUpdated()
        {
            _moneyView.SetAmountOfResources(_moneyModel.AmountOfResourseType);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}