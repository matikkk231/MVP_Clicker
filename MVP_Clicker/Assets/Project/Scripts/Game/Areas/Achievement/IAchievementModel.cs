using System;

namespace Project.Scripts.Game.Areas.Achievement
{
    public interface IAchievementModel
    {
        public event Action Updated;
        public event Action AchievementCompleted;

        public int RequiredPointsToComplete { get; }
        public int CurrentPoints { get; }
        public string Description { get; }
        public string Name { get; }
    }
}