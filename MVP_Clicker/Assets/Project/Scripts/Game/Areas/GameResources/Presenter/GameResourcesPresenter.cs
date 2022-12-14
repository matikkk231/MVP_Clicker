using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Resource.Presenter;

namespace Project.Scripts.Game.Areas.GameResources.Presenter
{
    public class GameResourcesPresenter : IDisposable
    {
        private readonly List<GameResourcePresenter> _gameResourcePresenters = new();

        public GameResourcesPresenter(IGameResourcesView view, IGameResourcesModel model)
        {
            _gameResourcePresenters.Add(new GameResourcePresenter(view.Money, model.Collection[model.Id.Money]));
            _gameResourcePresenters.Add(new GameResourcePresenter(view.DamagePerTap,
                model.Collection[model.Id.DamagePerTap]));
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