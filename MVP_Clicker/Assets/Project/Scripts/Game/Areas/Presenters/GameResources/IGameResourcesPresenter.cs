using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public interface IGameResourcesPresenter
    {
        public IGameResourcesModel GetGameResourcesModel { get; }
        public IGameResourcesView GetGameResourcesView { get; }
    }
}