using System;
using System.Net.NetworkInformation;
using Project.Scripts.Game.Areas.LevelSystem.Data;

namespace Project.Scripts.Game.Areas.LevelSystem.Model
{
    public class LevelSystemModel : ILevelSystemModel
    {
        public event Action GotLevelUp;
        public event Action Updated;

        private readonly ILevelSystemData _data;

        public int CurrentExperience
        {
            get => _data.CurrentExperience;
            set => _data.CurrentExperience = value;
        }

        public int ExperienceBeforeLeveUp => _data.ExperienceBeforeLevelUp;

        public int CurrentLevel
        {
            get => _data.CurrentLevel;
            set
            {
                _data.CurrentLevel = value;
                Updated?.Invoke();
            }
        }

        public LevelSystemModel(ILevelSystemData data)
        {
            _data = data.IsInitialized ? data : InitializeData(data);
        }

        private ILevelSystemData InitializeData(ILevelSystemData data)
        {
            data.CurrentExperience = 0;
            data.CurrentLevel = 1;
            data.ExperienceBeforeLevelUp = 3;
            data.IsInitialized = true;
            return data;
        }

        public void LevelUp()
        {
            GotLevelUp?.Invoke();
        }
    }
}