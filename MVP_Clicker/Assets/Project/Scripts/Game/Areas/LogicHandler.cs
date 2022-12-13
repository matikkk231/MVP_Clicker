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
            _monster.CurrentHP -= _gameResources.Collection["damagePerTap"].Amount;
        }
        private void AddListeners()
        {
            _monster.Damaged += OnMonsterDamaged;
        }

        private void RemoveListeners()
        {
            _monster.Damaged -= OnMonsterDamaged;
        }
    }
}