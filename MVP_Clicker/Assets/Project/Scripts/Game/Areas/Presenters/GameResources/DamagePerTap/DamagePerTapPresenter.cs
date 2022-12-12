using System;
using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class DamagePerTapPresenter : IGameResourcesPresenter, IDisposable
    {
        private IGameResourcesView _damagePerTapView;
        private IGameResourcesModel _damagePerTapModel;


        public IGameResourcesModel GetGameResourcesModel
        {
            get => _damagePerTapModel;
        }

        public IGameResourcesView GetGameResourcesView
        {
            get => _damagePerTapView;
        }

        public DamagePerTapPresenter(IGameResourcesView view, IGameResourcesModel model)
        {
            _damagePerTapView = view;
            _damagePerTapModel = model;
            AddListeners();
            _damagePerTapView.SetAmountOfResources(_damagePerTapModel.AmountOfResourseType);
        }

        private void OnUpdated()
        {
            _damagePerTapView.SetAmountOfResources(_damagePerTapModel.AmountOfResourseType);
        }

        private void AddListeners()
        {
            _damagePerTapModel.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _damagePerTapModel.Updated -= OnUpdated;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}