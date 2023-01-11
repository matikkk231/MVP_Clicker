using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Camera.Presenter;
using Project.Scripts.Game.Areas.MainMenu.Model;
using Project.Scripts.Game.Areas.MainMenu.Presenter;
using Project.Scripts.Game.Base.GameConfigs;
using Project.Scripts.Game.Base.GameData;
using Project.Scripts.Game.Base.GameModels;
using Project.Scripts.Game.Base.GameViews;

namespace Project.Scripts.Game.Base.GamePresenters
{
    public class GamePresenter : IDisposable
    {
        private readonly List<IDisposable> _presenters = new();

        public GamePresenter(IGameModels models, IGameViews views, IGameConfigs configs)
        {
            _presenters.Add(new CameraPresenter(views.Camera, models.Camera));
            _presenters.Add(new MainMenuPresenter(views.MainMenu, models.MainMenu, configs));
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}