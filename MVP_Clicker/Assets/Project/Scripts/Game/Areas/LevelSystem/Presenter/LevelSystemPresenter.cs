using System;
using Project.Scripts.Game.Areas.LevelSystem.Data;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.LevelSystem.View;

namespace Project.Scripts.Game.Areas.LevelSystem.Presenter
{
    public class LevelSystemPresenter : IDisposable
    {
        private readonly ILevelSystemView _view;
        private readonly ILevelSystemModel _model;
        private ILevelSystemData _data;

        public LevelSystemPresenter(ILevelSystemView view, ILevelSystemModel model)
        {
            _view = view;
            _model = model;
            _data = new LevelSystemData();
            AddListeners();
            OnUpdated();
        }

        public LevelSystemPresenter(ILevelSystemView view, ILevelSystemModel model, ILevelSystemData data)
        {
            _view = view;
            _model = model;
            _data = data;
            AddListeners();
            OnUpdated();
        }

        private void OnUpdated()
        {
            _view.SetCurrentLevel(_model.CurrentLevel);
        }

        private void AddListeners()
        {
            _model.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _model.Updated -= OnUpdated;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}