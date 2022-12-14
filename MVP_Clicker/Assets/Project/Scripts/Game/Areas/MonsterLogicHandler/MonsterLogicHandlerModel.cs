using System;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas
{
    public class MonsterLogicHandlerModel : IDisposable
    {
        private readonly IGameResourcesModel _gameResources;
        private readonly IMonsterModel _monster;

        public MonsterLogicHandlerModel(IGameResourcesModel gameResources, IMonsterModel monster)
        {
            _gameResources = gameResources;
            _monster = monster;
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
            _monster.CurrentHp = _monster.FullHp;
            _gameResources.Collection[_gameResources.Id.Money].Amount += _monster.RewardForKilling;
        }

        private void AddListeners()
        {
            _monster.Damaged += OnMonsterDamaged;
            _monster.Died += OnMonsterDied;
        }

        private void RemoveListeners()
        {
            _monster.Damaged -= OnMonsterDamaged;
            _monster.Died -= OnMonsterDied;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}