using System;

namespace Project.Scripts.Game.Areas.Models.Monster
{
    public class MonsterModel : IMonsterModel
    {
        public event Action Updated;
        public event Action MonsterDied;
        public event Action GotDamageByTap;


        private int _fullMonsterHP;
        private int _currentMonsterHP;
        private int _monsterReward;
        private int _currentMonstersLevel;


        public int CurrentMonsterHP
        {
            get => _currentMonsterHP;
            set
            {
                _currentMonsterHP = value;
                if (_currentMonsterHP <= 0)
                {
                    DieMonster();
                }

                Updated?.Invoke();
            }
        }

        public int MonsterReward
        {
            get => _monsterReward;
            set
            {
                _monsterReward = value;
                Updated?.Invoke();
            }
        }

        public MonsterModel()
        {
            _monsterReward = 2;
            _currentMonsterHP = 5;
            _fullMonsterHP = 5;
        }

        public void DieMonster()
        {
            _currentMonsterHP = _fullMonsterHP;
            MonsterDied?.Invoke();
        }

        public void GetDamage()
        {
            GotDamageByTap?.Invoke();
        }

        public void LevelUpMonster()
        {
            _monsterReward += 1;
            _fullMonsterHP += 2;
        }
    }
}