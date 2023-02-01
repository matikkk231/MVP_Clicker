using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement.Data;

namespace Project.Scripts.Game.Areas.Achievements.Data
{
    public interface IAchievementsData
    {
        public Dictionary<string, IAchievementData> Collection { get; }
        public bool IsInitialized { get; set; }
    }
}