using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.Achievement.Data
{
    public interface IAchievementData
    {
        public int CurrentPoints { get; set; }
        public string Id { get; set; }
    }
}