using Newtonsoft.Json;

namespace Project.Scripts.Game.Areas.LevelSystem.Data
{
    public class LevelSystemData : ILevelSystemData
    {
        [JsonProperty("CurrentLevelData")] public int CurrentLevelValue;

        [JsonProperty("CurrentExperienceData")]
        public int CurrentExperienceValue;

        [JsonProperty("ExperienceBeforeLevelUpData")]
        public int ExperienceBeforeLevelUpValue;

        [JsonProperty("IsLevelSystemDataInitialized")]
        public bool IsInitialized { get; set; }

        public int CurrentLevel
        {
            get => CurrentLevelValue;
            set => CurrentLevelValue = value;
        }

        public int CurrentExperience
        {
            get => CurrentExperienceValue;
            set => CurrentExperienceValue = value;
        }

        public int ExperienceBeforeLevelUp
        {
            get => ExperienceBeforeLevelUpValue;
            set => ExperienceBeforeLevelUpValue = value;
        }

        public LevelSystemData()
        {
            CurrentLevel = 0;
            CurrentExperience = 0;
            ExperienceBeforeLevelUp = 0;
        }
    }
}