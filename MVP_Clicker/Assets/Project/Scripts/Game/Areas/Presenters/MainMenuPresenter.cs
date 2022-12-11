using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Models.Canvas;
using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.Canvas;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class MainMenuPresenter : IDisposable

    {
        private readonly IMainMenuModel _mainMenuModel;
        private readonly IViewBox<IMainMenuView> _canvasViewBox;
        private readonly MoneyPresenter _moneyPresenter;

     
        public MainMenuPresenter(IViewCreate<IMainMenuView> canvasViewBox, IMainMenuModel mainMenuModel)
        {
            _mainMenuModel = mainMenuModel;
            _canvasViewBox = canvasViewBox.CreateObject();
            _moneyPresenter = new MoneyPresenter(_canvasViewBox.GetView.GetMoneyView, _mainMenuModel.GetMoneyModel);
        }


        public void Dispose()
        {
        }
    }
}