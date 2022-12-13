using System;
using UnityEngine.PlayerLoop;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public class MonsterModel : IMonsterModel
    {
        public event Action Updated;
        public event Action Died;
        public event Action Damaged;

        private int _currentHP;
        private int _fullHP;
        private int _rewardForKilling;

        public int CurrentHP
        {
            get => _currentHP;
            set
            {
                _currentHP = value;
                Updated?.Invoke();
            }
        }

        public int FullHP
        {
            get => _fullHP;
            set
            {
                _fullHP = value;
                Updated?.Invoke();
            }
        }

        public int RewardForKilling
        {
            get => _rewardForKilling;
            set
            {
                _rewardForKilling = value;
                Updated?.Invoke();
            }
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }

        public MonsterModel(int fullHp, int rewardForKilling)
        {
            FullHP = fullHp;
            RewardForKilling = rewardForKilling;
            CurrentHP = FullHP;
        }
    }
}