using System;
using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class LevelPresenter : ILevelPresenter, IDisposable
    {
        private ILevelModel _levelModel;
        private ILevelView _levelView;

        public ILevelModel GetLevelModel
        {
            get => _levelModel;
        }

        public ILevelView GetLevelView
        {
            get => _levelView;
        }

        public LevelPresenter(ILevelView view, ILevelModel model)
        {
            _levelModel = model;
            _levelView = view;
            AddListeners();
            _levelView.SetCurrentLevel(_levelModel.CurrentLevel);
        }

        private void OnUpdated()
        {
            _levelView.SetCurrentLevel(_levelModel.CurrentLevel);
        }

        private void AddListeners()
        {
            _levelModel.Updated += OnUpdated;
        }

        private void RemoveListeners()
        {
            _levelModel.Updated -= OnUpdated;
        }


        public void Dispose()
        {
            RemoveListeners();
        }
    }
}