using System;
using Project.Scripts.Game.Areas.LevelSystem.Data;

namespace Project.Scripts.Game.Areas.LevelSystem.Model
{
    public class LevelSystemModel : ILevelSystemModel
    {
        public event Action GotLevelUp;
        public event Action Updated;


        private int _currentLevel;
        public int CurrentExperience { get; set; }
        public int ExperienceBeforeLeveUp { get; }

        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                Updated?.Invoke();
            }
        }

        public LevelSystemModel()
        {
            const int startExperience = 0;
            CurrentExperience = startExperience;

            int startLevel = 1;
            CurrentLevel = startLevel;
            ExperienceBeforeLeveUp = 3;
        }

        public LevelSystemModel(ILevelSystemData data)
        {
            CurrentExperience = data.CurrentExperience;
            CurrentLevel = data.CurrentLevel;
            ExperienceBeforeLeveUp = data.ExperienceBeforeLevelUp;
        }

        public void LevelUp()
        {
            GotLevelUp?.Invoke();
        }
    }
}