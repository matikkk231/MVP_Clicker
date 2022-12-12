using System;

namespace Project.Scripts.Game.Areas.Models.GameResources
{
    public interface ILevelModel
    {
        public event Action Updated;
        public event Action GotUpLevel;
        public int CurrentLevel { get; set; }
        public int CurrentExperience { get; set; }
    }
}