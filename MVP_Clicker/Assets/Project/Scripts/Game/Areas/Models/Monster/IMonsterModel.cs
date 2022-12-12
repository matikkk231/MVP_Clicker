using System;
using Unity.VisualScripting;

namespace Project.Scripts.Game.Areas.Models.Monster
{
    public interface IMonsterModel
    {
        event Action Updated;
        public event Action MonsterDied;
        public event Action GotDamageByTap;
        public int CurrentMonsterHP { get; set; }
        public int MonsterReward { get; set; }

        public void LevelUpMonster();
        public void GetDamage();
    }
}