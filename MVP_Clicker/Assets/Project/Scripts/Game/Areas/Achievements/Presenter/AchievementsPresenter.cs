using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model;
using Project.Scripts.Game.Areas.Achievements.Config;
using Project.Scripts.Game.Areas.Achievements.Model;
using Project.Scripts.Game.Areas.Achievements.View;

namespace Project.Scripts.Game.Areas.Achievements.Presenter
{
    public class AchievementsPresenter : IDisposable
    {
        private readonly List<AchievementPresenter> _presenters;

        public AchievementsPresenter(IAchievementsView view, IAchievementsModel models, IAchievementsConfig config)
        {
            _presenters = new List<AchievementPresenter>();
            foreach (var element in config.Collection)
            {
                var achievementView = view.CreateAchievement();

                _presenters.Add(new AchievementPresenter(achievementView, models.Collection[element.Id], element));
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}