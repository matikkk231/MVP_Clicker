namespace Project.Scripts.Game.Areas.LevelSystem.Data
{
    public interface ILevelSystemData
    {
        public bool IsInitialized { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentExperience { get; set; }
        public int ExperienceBeforeLevelUp { get; set; }
    }
}