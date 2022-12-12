using System;
using Project.Scripts.Game.Areas.Presenters;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Models.GameResources
{
    public class LevelModel : ILevelModel
    {
        public event Action Updated;
        public event Action GotUpLevel;

        private int _currentLevel;
        private int _currentExperience;
        private int _experienceUntilLevelUp;


        public int CurrentExperience
        {
            get => _currentExperience;
            set
            {
                _currentExperience = value;
                if (_currentExperience >= _experienceUntilLevelUp)
                {
                    LevelUp();
                }
            }
        }


        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                Updated?.Invoke();
            }
        }


        public LevelModel()
        {
            _currentLevel = 1;
            _experienceUntilLevelUp = 3;
        }

        private void LevelUp()
        {
            CurrentLevel++;
            CurrentExperience = 0;
            GotUpLevel?.Invoke();
        }
    }
}