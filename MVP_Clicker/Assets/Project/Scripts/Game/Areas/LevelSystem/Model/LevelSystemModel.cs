using System;

namespace Project.Scripts.Game.Areas.LevelSystem.Model
{
    public class LevelSystemModel : ILevelSystemModel
    {
        public event Action LevelUP;
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

        public void LevelUp()
        {
            LevelUP?.Invoke();
        }

        public LevelSystemModel()
        {
            const int startExperience = 0;
            CurrentExperience = startExperience;

            int startLevel = 1;
            CurrentLevel = startLevel;
            ExperienceBeforeLeveUp = 3;
        }
    }
}