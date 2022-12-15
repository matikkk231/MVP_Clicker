using System;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public class MonsterModel : IMonsterModel
    {
        public event Action Updated;
        public event Action Died;
        public event Action Damaged;

        private int _currentHp;

        public int CurrentHp
        {
            get => _currentHp;
            set
            {
                _currentHp = value;
                Updated?.Invoke();
            }
        }

        public int FullHp { get; set; }

        public int RewardForKilling { get; set; }

        public void Damage()
        {
            Damaged?.Invoke();
        }

        public void Die()
        {
            Died?.Invoke();
        }


        public MonsterModel(int fullHp, int rewardForKilling)
        {
            FullHp = fullHp;
            RewardForKilling = rewardForKilling;
            CurrentHp = FullHp;
        }
    }
}