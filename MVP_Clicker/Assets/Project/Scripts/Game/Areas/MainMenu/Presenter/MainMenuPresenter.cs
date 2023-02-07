using System;
using System.Collections.Generic;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.BonusesShop.Presenter;
using Project.Scripts.Game.Areas.GameResources.Presenter;
using Project.Scripts.Game.Areas.LevelSystem.Presenter;
using Project.Scripts.Game.Areas.MainMenu.Model;
using Project.Scripts.Game.Areas.Monster.Presenter;
using Project.Scripts.Game.Areas.Skills.Presenter;
using Project.Scripts.Game.Base.GameConfigs;

namespace Project.Scripts.Game.Areas.MainMenu.Presenter
{
    public class MainMenuPresenter : IDisposable
    {
        private readonly IBoxView<IMainMenuView> _boxMainMenuView;
        private readonly IMainMenuModel _model;
        private readonly List<IDisposable> _presenters = new();

        public MainMenuPresenter(IViewCreator<IMainMenuView> viewCreator, IMainMenuModel model, IGameConfigs configs)
        {
            _boxMainMenuView = viewCreator.CreateObject();
            _model = model;

            _presenters.Add(new GameResourcesPresenter(_boxMainMenuView.View.GameResources, _model.GameResources,
                configs.GameResourcesConfig));
            _presenters.Add(new MonsterPresenter(_boxMainMenuView.View.Monster, _model.Monster, configs.MonsterConfig));
            _presenters.Add(new LevelSystemPresenter(_boxMainMenuView.View.LevelSystem, _model.LevelSystem));
            _presenters.Add(new BonusesShopPresenter(_boxMainMenuView.View.BonusesShop, _model.BonusesShop,
                configs.BonusesShopConfig));
            _presenters.Add(new SkillsPresenter(model.Skills, _boxMainMenuView.View.SkillMenu,
                configs.SkillsConfig));
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
                _boxMainMenuView.Destroy();
            }
        }
    }
}