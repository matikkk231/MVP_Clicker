using System;
using System.Collections;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Resource.Model;
using Project.Scripts.Game.Areas.Skill.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.Model
{
    public class VampireSkillModel : ISkillModel, IDisposable
    {
        public event Action<float> CooldownUpdated;

        private int _damageIncreasedAmount;
        private readonly IMonsterModel _monster;
        private readonly IGameResourceModel _gameResource;
        private readonly ICoroutineStarterService _coroutineStarterService;
        private float _cooldownRemains;
        private bool IsActive { get; set; }
        private int RecoveryDuration { get; }
        private bool SkillReady { get; set; }
        private int BoostValue { get; }
        private int ActivityDuration { get; }
        private bool _isActive;
        public string Id { get; set; }

        private float CooldownRemains
        {
            get => _cooldownRemains;
            set
            {
                _cooldownRemains = value;
                CooldownUpdated?.Invoke(_cooldownRemains);
            }
        }


        public VampireSkillModel(IMonsterModel monster, IGameResourceModel gameResource,
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
            AddListeners();
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
            _isActive = true;
            IsActive = true;
            yield return new WaitForSeconds(ActivityDuration);
            _cooldownRemains = 1;
            _isActive = false;
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
            if (_isActive)
            {
                _gameResource.Amount += BoostValue;
                _damageIncreasedAmount += BoostValue;
            }
        }

        private void AddListeners()
        {
            _monster.Died += BecomeStronger;
        }

        private void RemoveListeners()
        {
            _monster.Died -= BecomeStronger;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}