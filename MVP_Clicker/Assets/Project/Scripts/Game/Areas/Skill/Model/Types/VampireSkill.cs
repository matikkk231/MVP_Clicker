using System;
using System.Collections;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Skill.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.Model
{
    public class VampireSkill : ISkillModel
    {
        public event Action<float> UpdatedCooldown;

        private int _damageIncreasedAmount;
        private readonly IMonsterModel _monster;
        private readonly IGameResourceModel _gameResource;
        private readonly ICoroutineStarterService _coroutineStarterService;
        private float _cooldownRemains;

        private int ActivityDuration { get; }
        public string Id { get; set; }

        public float CooldownRemains
        {
            get => _cooldownRemains;
            set
            {
                _cooldownRemains = value;
                UpdatedCooldown?.Invoke(_cooldownRemains);
            }
        }

        public bool IsActive { get; set; }

        private int RecoveryDuration { get; }
        private bool SkillReady { get; set; }
        private int BoostValue { get; }

        public VampireSkill(IMonsterModel monster, IGameResourceModel gameResource,
            ICoroutineStarterService coroutineStarterService, ISkillConfig config)
        {
            _gameResource = gameResource;
            _monster = monster;
            _coroutineStarterService = coroutineStarterService;
            SkillReady = true;
            ActivityDuration = config.ActivityDuration;
            RecoveryDuration = config.RecoveryDuration;
            BoostValue = config.BoostValue;
            Id = config.Id;
        }


        public void TryActivate()
        {
            if (SkillReady)
            {
                _coroutineStarterService.StartCurrentCoroutine(Activate());
            }
        }

        private IEnumerator Activate()
        {
            SkillReady = false;
            _monster.Died += BecomeStronger;
            IsActive = true;
            yield return new WaitForSeconds(ActivityDuration);
            _cooldownRemains = 1;
            _monster.Died -= BecomeStronger;
            _gameResource.Amount -= _damageIncreasedAmount;
            _damageIncreasedAmount = 0;
            while (CooldownRemains > 0)
            {
                yield return new WaitForSeconds(1);
                double cooldownDecrease = 1.0 / RecoveryDuration;
                CooldownRemains -= (float)cooldownDecrease;
            }

            SkillReady = true;
        }

        private void BecomeStronger()
        {
            _gameResource.Amount += BoostValue;
            _damageIncreasedAmount += BoostValue;
        }
    }
}