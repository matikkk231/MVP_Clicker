using System;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas
{
    public class MonsterLogicHandlerModel : IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IMonsterModel _monster;
        private readonly ILevelSystemModel _levelSystem;

        public MonsterLogicHandlerModel(IGameResourcesModel gameResources, IMonsterModel monster,
            ILevelSystemModel levelSystem)
        {
            _gameResources = gameResources;
            _monster = monster;
            _levelSystem = levelSystem;
            AddListeners();
        }

        private void OnMonsterDamaged()
        {
            if (_monster.CurrentHp - _gameResources.Collection[_gameResources.Id.DamagePerTap].Amount > 0)
            {
                _monster.CurrentHp -= _gameResources.Collection[_gameResources.Id.DamagePerTap].Amount;
            }
            else
            {
                _monster.Die();
            }
        }

        private void OnMonsterDied()
        {
            if (_levelSystem.CurrentExperience++ <= _levelSystem.ExperienceBeforeLeveUp)
            {
                _levelSystem.CurrentExperience++;
            }
            else
            {
                _levelSystem.LevelUp();
            }

            _monster.CurrentHp = _monster.FullHp;
            _gameResources.Collection[_gameResources.Id.Money].Amount += _monster.RewardForKilling;
        }

        private void OnLevelUp()
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
            _levelSystem.LevelUP += OnLevelUp;
        }

        private void RemoveListeners()
        {
            _monster.Damaged -= OnMonsterDamaged;
            _monster.Died -= OnMonsterDied;
            _levelSystem.LevelUP -= OnLevelUp;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}