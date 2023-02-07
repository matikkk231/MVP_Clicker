using System;
using Project.Scripts.Game.Areas.Achievement.Data;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model
{
    public class MonsterKillingAchievementModel : IAchievementModel, IDisposable
    {
        public event Action Updated;
        public event Action AchievementCompleted;

        private readonly IMonsterModel _monster;
        private readonly IAchievementData _data;

        public int RequiredPointsToComplete { get; }

        public int CurrentPoints
        {
            get => _data.CurrentPoints;
            private set => _data.CurrentPoints = value;
        }

        public string Description { get; }
        public string Name { get; }

        public MonsterKillingAchievementModel(IMonsterModel monster, IAchievementConfig config, IAchievementData data)
        {
            _monster = monster;
            _data = data;
            AddListeners();
            RequiredPointsToComplete = config.RequiredPointsToComplete;
            Description = config.Description;
            Name = config.Name;
        }

        private void GetPoint()
        {
            int pointsBeAfterGettingPoint = CurrentPoints + 1;
            if (pointsBeAfterGettingPoint >= RequiredPointsToComplete)
            {
                CompleteAchievement();
            }

            CurrentPoints++;
            Updated?.Invoke();
        }

        private void CompleteAchievement()
        {
            AchievementCompleted?.Invoke();
            RemoveListeners();
        }

        private void AddListeners()
        {
            _monster.Died += GetPoint;
        }

        private void RemoveListeners()
        {
            _monster.Died -= GetPoint;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}