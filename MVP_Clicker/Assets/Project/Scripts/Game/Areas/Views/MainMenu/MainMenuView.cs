using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.GameResources;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.Canvas
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField] private MoneyView _moneyView;

        public IGameResourcesView GetMoneyView
        {
            get => _moneyView;
        }
    }
}