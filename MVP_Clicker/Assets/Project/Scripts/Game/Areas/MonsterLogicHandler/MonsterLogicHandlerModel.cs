using System;
using System.Collections;
using Project.Scripts.Core.CoroutineStarterService;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;
using UnityEngine;

namespace Project.Scripts.Game.Areas
{
    public class MonsterLogicHandlerModel : IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IMonsterModel _monster;
        private readonly ILevelSystemModel _levelSystem;


        public MonsterLogicHandlerModel(IGameResourcesModel gameResources, IMonsterModel monster,
            ILevelSystemModel levelSystem, ICoroutineStarterService coroutineStarterService)
        {
            _gameResources = gameResources;
            _monster = monster;
            _levelSystem = levelSystem;
            AddListeners();
            coroutineStarterService.StartCurrentCoroutine(DamageMonsterEverySecond());
        }

        private void OnMonsterDamaged()
        {
            bool hasMonsterEnoughHp =
                _monster.CurrentHp - _gameResources.CollectionOfGameResourceModels[_monster.ResourceDamagingMonster]
                    .Amount > 0;
            if (hasMonsterEnoughHp)
            {
                ReduceMonsterHp();
            }
            else
            {
                _monster.Die();
            }
        }

        private void ReduceMonsterHp()
        {
            _monster.CurrentHp -=
                _gameResources.CollectionOfGameResourceModels[_monster.ResourceDamagingMonster].Amount;
        }

        private void OnMonsterDied()
        {
            bool isGettingLevelUpAfterKillingMonster =
                _levelSystem.CurrentExperience++ <= _levelSystem.ExperienceBeforeLeveUp;
            if (isGettingLevelUpAfterKillingMonster)
            {
                GetExperienceFromMonster();
            }
            else
            {
                _levelSystem.LevelUp();
            }

            BornMonster();
            GetRewardFromMonster();
        }

        private void GetExperienceFromMonster()
        {
            _levelSystem.CurrentExperience++;
        }

        private void GetRewardFromMonster()
        {
            _gameResources.CollectionOfGameResourceModels[_monster.TypeOfRewardForKilling].Amount +=
                _monster.RewardForKilling;
        }

        private void BornMonster()
        {
            _monster.CurrentHp = _monster.FullHp;
        }

        private void OnGotLevelUp()
        {
            _levelSystem.CurrentLevel++;
            _levelSystem.CurrentExperience = 0;

            int additionHp = 2;
            _monster.FullHp += additionHp;
            _monster.RewardForKilling += 1;
        }

        private void AddListeners()
        {
            _monster.Damaged += OnMonsterDamaged;
            _monster.Died += OnMonsterDied;
            _levelSystem.GotLevelUp += OnGotLevelUp;
        }

        private void RemoveListeners()
        {
            _monster.Damaged -= OnMonsterDamaged;
            _monster.Died -= OnMonsterDied;
            _levelSystem.GotLevelUp -= OnGotLevelUp;
        }

        private IEnumerator DamageMonsterEverySecond()
        {
            while (true)
            {
                if (_monster.CurrentHp > _gameResources
                        .CollectionOfGameResourceModels[_monster.ResourceDamagingMonsterEverySecond].Amount)
                {
                    _monster.CurrentHp -= _gameResources
                        .CollectionOfGameResourceModels[_monster.ResourceDamagingMonsterEverySecond].Amount;
                }
                else
                {
                    _monster.Die();
                }

                yield return new WaitForSeconds(1);
            }
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}