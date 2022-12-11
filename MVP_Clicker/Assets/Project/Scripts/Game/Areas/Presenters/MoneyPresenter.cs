using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class MoneyPresenter : IDisposable
    {
        private IGameResourcesView _viewMoney;
        private IGameResourcesModel _moneyModel;

        public MoneyPresenter(IGameResourcesView view, IGameResourcesModel model)
        {
            _viewMoney = view;
            _moneyModel = model;
            AddListeners();
            view.SetAmountOfResources(_moneyModel.AmountOfResourseType);
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
            _viewMoney.SetAmountOfResources(_moneyModel.AmountOfResourseType);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}