using System;

namespace Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model
{
    public class AchievementPresenter : IDisposable
    {
        private readonly IAchievementModel _model;
        private readonly IAchievementView _view;

        public AchievementPresenter(IAchievementView view,
            IAchievementModel model, IAchievementConfig config)
        {
            _view = view;
            _model = model;
            _view.Description = config.Description;
            _view.Name = config.Name;
            _view.AchievementImage = config.AchievementImage;
            _view.ImageWhenCompleted = config.CompletedAchievementImage;
            _view.RequiredPointsToComplete = config.RequiredPointsToComplete;
            AddListeners();
        }

        private void OnPointsUpdated()
        {
            _view.CurrentPoints = _model.CurrentPoints;
            _view.RequiredPointsToComplete = _model.RequiredPointsToComplete;
            _view.Description = _model.Description;
            _view.Name = _model.Name;
        }

        private void OnAchievementCompleted()
        {
            _view.CompleteAchievement();
        }

        private void AddListeners()
        {
            _model.Updated += OnPointsUpdated;
            _model.AchievementCompleted += OnAchievementCompleted;
        }

        private void RemoveListeners()
        {
            _model.Updated -= OnPointsUpdated;
            _model.AchievementCompleted -= OnAchievementCompleted;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}