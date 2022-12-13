using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Resource.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.MainMenu.View
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField] private GameResourcesView gameResources;

        public IGameResourcesView GameResources => gameResources;
    }
}