using Project.Scripts.Game.Areas.Achievements.View;
using Project.Scripts.Game.Areas.BonusesShop.View;
using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.LevelSystem.View;
using Project.Scripts.Game.Areas.Monster.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.MainMenu.View
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField] private GameResourcesView _gameResources;
        [SerializeField] private MonsterView _monster;
        [SerializeField] private LevelSystemView _level;
        [SerializeField] private BonusesShopView _bonusesShop;
        [SerializeField] private AchievementsView _achievements;

        public IGameResourcesView GameResources => _gameResources;
        public IMonsterView Monster => _monster;
        public ILevelSystemView LevelSystem => _level;
        public IBonusesShopView BonusesShopView => _bonusesShop;
        public IAchievementsView Achievements => _achievements;
    }
}