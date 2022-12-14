using System;
using System.Collections.Generic;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.BonusesShop.Presenter;
using Project.Scripts.Game.Areas.GameResources.Presenter;
using Project.Scripts.Game.Areas.LevelSystem.Presenter;
using Project.Scripts.Game.Areas.MainMenu.Model;
using Project.Scripts.Game.Areas.Monster.Presenter;
using Project.Scripts.Game.Base.GameConfigs;

namespace Project.Scripts.Game.Areas.MainMenu.Presenter
{
    public class MainMenuPresenter : IDisposable
    {
        private IBoxView<IMainMenuView> _boxView;
        private IMainMenuModel _model;
        private List<IDisposable> _presenters = new();

        public MainMenuPresenter(IViewCreator<IMainMenuView> viewCreator, IMainMenuModel model, IGameConfigs configs)
        {
            _boxView = viewCreator.CreateObject();
            _model = model;

            _presenters.Add(new GameResourcesPresenter(_boxView.View.GameResources, _model.GameResources,
                configs.GameResourcesConfig));
            _presenters.Add(new MonsterPresenter(_boxView.View.Monster, _model.Monster, configs.MonsterConfig));
            _presenters.Add(new LevelSystemPresenter(_boxView.View.LevelSystem, _model.LevelSystem));
            _presenters.Add(new BonusesShopPresenter(_boxView.View.BonusesShopView, _model.BonusesShop,
                configs.BonusesShopConfig));
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
                _boxView.Destroy();
            }
        }
    }
}