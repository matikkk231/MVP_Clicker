using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Presenters
{
    public interface ILevelPresenter
    {
        public ILevelModel GetLevelModel { get; }
        public ILevelView GetLevelView { get; }
    }
}