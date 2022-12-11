using Project.Scripts.Game.Areas.Models.GameResources;
using UnityEngine.UIElements;

namespace Project.Scripts.Game.Areas.Models.Canvas
{
    public class MainMenuModel : IMainMenuModel
    {
        private IMainMenuModel _mainMenuModelImplementation;
        private IGameResourcesModel _money;

        public IGameResourcesModel GetMoneyModel
        {
            get => _money;
        }

        public MainMenuModel()
        {
            _money = new MoneyModel();
        }
    }
}