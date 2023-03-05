using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement;

namespace Project.Scripts.Game.Areas.Achievements.Config
{
    public interface IAchievementsConfig
    {
        public List<IAchievementConfig> Collection { get; }
    }
}