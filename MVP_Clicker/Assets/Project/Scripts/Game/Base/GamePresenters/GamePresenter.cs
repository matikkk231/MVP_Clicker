using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Presenters;
using Project.Scripts.Game.Base.GameModels;
using Project.Scripts.Game.Base.GameViews;

namespace Project.Scripts.Game.Base.GamePresenters
{
    public class GamePresenter: IDisposable
    {
        private readonly List<IDisposable> _presenters = new();
        public GamePresenter(IGameModels models, IGameViews views)
        {
            _presenters.Add(new CameraPresenter(views.Camera, models.CameraModel));
            
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