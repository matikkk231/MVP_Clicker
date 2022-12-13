using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas
{
    public class LogicHandler
    {
        private IGameResourcesModel _gameResources;
        private IMonsterModel _monster;

        public LogicHandler(IGameResourcesModel gameResources, IMonsterModel monster)
        {
            _gameResources = gameResources;
            _monster = monster;
            AddListeners();
        }

        private void OnMonsterDamaged()
        {
            if (_monster.CurrentHP - _gameResources.Collection["damagePerTap"].Amount > 0)
            {
                _monster.CurrentHP -= _gameResources.Collection["damagePerTap"].Amount;
            }
            else
            {
                _monster.Die();
            }
        }

        private void OnMonsterDied()
        {
            _monster.CurrentHP = _monster.FullHP;
            _gameResources.Collection["money"].Amount += _monster.RewardForKilling;
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
        
    }
}