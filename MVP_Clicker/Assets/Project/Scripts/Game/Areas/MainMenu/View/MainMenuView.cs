using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Monster.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.MainMenu.View
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField] private GameResourcesView _gameResources;
        [SerializeField] private MonsterView _monster;

        public IGameResourcesView GameResources => _gameResources;
        public IMonsterView Monster => _monster;
    }
}