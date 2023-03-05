using UnityEngine;

namespace Project.Scripts.Game.Areas.Achievement
{
    public interface IAchievementConfig
    {
        public string Type { get; }
        public Sprite AchievementImage { get; }
        public Sprite CompletedAchievementImage { get; }
        public int RequiredPointsToComplete { get; }
        public string Description { get; }
        public string Name { get; }
        public string Id { get; }
    }
}