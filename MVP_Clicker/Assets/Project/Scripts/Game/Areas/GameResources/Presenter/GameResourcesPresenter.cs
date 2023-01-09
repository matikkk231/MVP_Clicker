using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Resource.Presenter;

namespace Project.Scripts.Game.Areas.GameResources.Presenter
{
    public class GameResourcesPresenter : IDisposable
    {
        private readonly List<GameResourcePresenter> _gameResourcePresenters = new();
        private IGameResourcesData _data;

        public GameResourcesPresenter(IGameResourcesView view, IGameResourcesModel model,
            IGameResourcesConfig gameResourcesConfig)
        {
            _gameResourcePresenters.Add(new GameResourcePresenter(view.Money,
                model.Collection[gameResourcesConfig.Money.Id]));
            _gameResourcePresenters.Add(new GameResourcePresenter(view.DamagePerTap,
                model.Collection[gameResourcesConfig.DamagePerTap.Id]));
            _data = new GameResourcesData();
        }

        public GameResourcesPresenter(IGameResourcesView view, IGameResourcesModel model, IGameResourcesData data)
        {
            _gameResourcePresenters.Add(new GameResourcePresenter(view.Money,
                model.Collection[data.Money.Id]));
            _gameResourcePresenters.Add(new GameResourcePresenter(view.DamagePerTap,
                model.Collection[data.DamagePerTap.Id]));
            _data = data;
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