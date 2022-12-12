using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Models.Monster;
using Project.Scripts.Game.Areas.Views.GameResources;
using UnityEngine.UIElements;

namespace Project.Scripts.Game.Areas.Models.Canvas
{
    public class MainMenuModel : IMainMenuModel
    {
        private IMainMenuModel _mainMenuModelImplementation;
        private IGameResourcesModel _money;
        private IGameResourcesModel _damagePerTapModel;
        private IMonsterModel _monsterModel;
        private ILevelModel _levelModel;

        public ILevelModel GetLevelModel
        {
            get => _levelModel;
        }

        public IGameResourcesModel GetMoneyModel
        {
            get => _money;
        }

        public IGameResourcesModel GetDamagePerTapModel
        {
            get => _damagePerTapModel;
        }

        public IMonsterModel GetMonsterModel
        {
            get => _monsterModel;
        }


        public MainMenuModel()
        {
            _money = new MoneyModel();
            _damagePerTapModel = new DamagePerTapModel();
            _monsterModel = new MonsterModel();
            _levelModel = new LevelModel();
        }
    }
}