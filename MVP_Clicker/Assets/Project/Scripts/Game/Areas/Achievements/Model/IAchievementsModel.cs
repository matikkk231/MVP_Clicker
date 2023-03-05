using System.Collections.Generic;
using Project.Scripts.Game.Areas.Achievement;

namespace Project.Scripts.Game.Areas.Achievements.Model
{
    public interface IAchievementsModel
    {
        public Dictionary<string, IAchievementModel> Collection { get; }
    }
}