using System;
using Project.Scripts.Game.Areas.Monster.Config;
using Project.Scripts.Game.Areas.Monster.Data;

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

        public MonsterModel(IMonsterConfig monsterConfig)
        {
            FullHp = monsterConfig.StartFullHp;
            RewardForKilling = monsterConfig.StartRewardForKilling;
            CurrentHp = FullHp;
        }

        public MonsterModel(IMonsterData data)
        {
            FullHp = data.FullHp;
            CurrentHp = data.CurrentHp;
            RewardForKilling = data.RewardForKilling;
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }

        public void Die()
        {
            Died?.Invoke();
        }
    }
}