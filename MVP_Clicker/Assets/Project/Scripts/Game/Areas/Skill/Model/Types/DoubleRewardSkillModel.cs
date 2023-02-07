using System;
using System.Collections;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Skill.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.Model
{
    public class DoubleRewardSkillModel : ISkillModel
    {
        public event Action<float> CooldownUpdated;

        private int _damageIncreasedAmount;
        private readonly IMonsterModel _monster;
        private readonly ICoroutineStarterService _coroutineStarterService;
        private float _cooldownRemains;
        private int ActivityDuration { get; }

        private float CooldownRemains
        {
            get => _cooldownRemains;
            set
            {
                _cooldownRemains = value;
                CooldownUpdated?.Invoke(_cooldownRemains);
            }
        }

        private int RecoveryDuration { get; }
        private bool SkillReady { get; set; }
        private int BoostValue { get; }

        public string Id { get; set; }


        public DoubleRewardSkillModel(IMonsterModel monster,
            ICoroutineStarterService coroutineStarterService, ISkillConfig config)
        {
            _monster = monster;
            _coroutineStarterService = coroutineStarterService;
            SkillReady = true;
            ActivityDuration = config.ActivityDuration;
            RecoveryDuration = config.RecoveryDuration;
            BoostValue = config.BoostValue;
            Id = config.Id;
        }

        public void Activate()
        {
            if (SkillReady)
            {
                _coroutineStarterService.StartCurrentCoroutine(ActivateCoroutine());
            }
        }

        private IEnumerator ActivateCoroutine()
        {
            SkillReady = false;
            var rewardIncrease = _monster.RewardForKilling * BoostValue;
            _monster.RewardForKilling += rewardIncrease;
            yield return new WaitForSeconds(ActivityDuration);
            _cooldownRemains = 1;
            _monster.RewardForKilling -= rewardIncrease;
            while (CooldownRemains > 0)
            {
                yield return new WaitForSeconds(1);
                double cooldownDecrease = 1.0 / RecoveryDuration;
                CooldownRemains -= (float)cooldownDecrease;
            }

            SkillReady = true;
        }
    }
}