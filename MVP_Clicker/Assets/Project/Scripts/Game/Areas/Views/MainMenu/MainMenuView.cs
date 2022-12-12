using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.GameResources;
using Project.Scripts.Game.Areas.Views.Monster;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.Canvas
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private DamagePerTapView _damagePerTapView;
        [SerializeField] private MonsterView _monsterView;
        [SerializeField] private LevelView _levelView;

        public ILevelView GetLevelView
        {
            get => _levelView;
        }

        public IGameResourcesView GetMoneyView
        {
            get => _moneyView;
        }

        public IGameResourcesView GetDamagePerTapView
        {
            get => _damagePerTapView;
        }

        public IMonsterView GetMonsterView
        {
            get => _monsterView;
        }
    }
}