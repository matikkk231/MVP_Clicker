using System;
using Project.Scripts.Game.Areas.Monster.Config;
using Project.Scripts.Game.Areas.Monster.Data;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public class MonsterModel : IMonsterModel
    {
        private readonly IMonsterData _data;
        private readonly IMonsterConfig _config;

        public event Action Updated;
        public event Action Died;
        public event Action Damaged;
        public string ResourceDamagingMonster => _config.ResourceDamagingMonster;
        public string TypeOfRewardForKilling => _config.TypeOfRewardForKilling;
        public string ResourceDamagingMonsterEverySecond => _config.ResourceDamagingMonsterEverySecond;


        public int CurrentHp
        {
            get => _data.CurrentHp;
            set
            {
                _data.CurrentHp = value;
                Updated?.Invoke();
            }
        }

        public int FullHp
        {
            get => _data.FullHp;
            set => _data.FullHp = value;
        }

        public int RewardForKilling
        {
            get => _data.RewardForKilling;
            set => _data.RewardForKilling = value;
        }


        public MonsterModel(IMonsterData data, IMonsterConfig config)
        {
            _config = config;
            _data = data.IsInitialized ? data : InitializeData(data);
        }

        private IMonsterData InitializeData(IMonsterData data)
        {
            data.CurrentHp = _config.StartFullHp;
            data.FullHp = _config.StartFullHp;
            data.RewardForKilling = _config.StartRewardForKilling;
            data.IsInitialized = true;
            return data;
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