using UnityEngine;

namespace Project.Scripts.Game.Areas.Achievement
{
    public interface IAchievementView
    {
        public int RequiredPointsToComplete { set; }
        public int CurrentPoints { set; }
        public void CompleteAchievement();
        public string Description { set; }
        public string Name { set; }
        public Sprite ImageWhenCompleted { set; }
        public Sprite AchievementImage { set; }
    }
}