using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Views.Canvas
{
    public interface IMainMenuView
    {
        public IGameResourcesView GetMoneyView { get; }
    }
}