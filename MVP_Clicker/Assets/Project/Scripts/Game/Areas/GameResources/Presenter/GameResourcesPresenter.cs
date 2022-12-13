using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Resource.Presenter;
using Unity.VisualScripting;

namespace Project.Scripts.Game.Areas.GameResources.Presenter
{
    public class GameResourcesPresenter : IDisposable
    {
        private readonly IGameResourcesView _view;
        private readonly IGameResourcesModel _model;
        private readonly List<GameResourcePresenter> _gameResourcePresenters = new();

        public GameResourcesPresenter(IGameResourcesView view, IGameResourcesModel model)
        {
            _view = view;
            _model = model;

            _gameResourcePresenters.Add(new GameResourcePresenter(_view.Money, _model.GameResources["money"]));
            _gameResourcePresenters.Add(new GameResourcePresenter(_view.DamagePerTap,
                _model.GameResources["damagePerTap"]));
        }

        public void Dispose()
        {
            foreach (var gameResourcePresenter in _gameResourcePresenters)
            {
                gameResourcePresenter.Dispose();
            }
        }
    }
}