using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Resource.View;

namespace Project.Scripts.Game.Areas.Resource.Presenter
{
    public class GameResourcePresenter : IDisposable
    {
        private IGameResourceView _view;
        private IGameResourceModel _model;


        public GameResourcePresenter(IGameResourceView view, IGameResourceModel model)
        {
            _view = view;
            _model = model;
            AddListeners();
            _view.SetAmount(_model.Amount);
        }

        private void AddListeners()
        {
            _model.Updated += OnUpdated;
        }

        private void RemoveListers()
        {
            _model.Updated -= OnUpdated;
        }

        private void OnUpdated()
        {
            _view.SetAmount(_model.Amount);
        }

        public void Dispose()
        {
            RemoveListers();
            
        }
    }
}