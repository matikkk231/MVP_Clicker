using System;
using Project.Scripts.Game.Areas.GameResource.Config;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Resource.View;

namespace Project.Scripts.Game.Areas.Resource.Presenter
{
    public class GameResourcePresenter : IDisposable
    {
        private readonly IGameResourceView _view;
        private readonly IGameResourceModel _model;

        public GameResourcePresenter(IGameResourceView view, IGameResourceModel model, IGameResourceConfig config)
        {
            _view = view;
            _model = model;
            _view.SetSprite(config.GameResourceSprite);
            AddListeners();
            _view.SetAmount(_model.Amount);
        }

        private void AddListeners()
        {
            _model.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _model.Updated -= OnUpdated;
        }

        private void OnUpdated()
        {
            _view.SetAmount(_model.Amount);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}