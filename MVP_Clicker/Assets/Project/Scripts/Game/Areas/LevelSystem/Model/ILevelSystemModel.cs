using System;

namespace Project.Scripts.Game.Areas.LevelSystem.Model
{
    public interface ILevelSystemModel
    {
        event Action LevelUP;
        event Action Updated;
        int CurrentExperience { get; set; }
        int ExperienceBeforeLeveUp { get; }
        int CurrentLevel { get; set; }

        void LevelUp();
    }
}