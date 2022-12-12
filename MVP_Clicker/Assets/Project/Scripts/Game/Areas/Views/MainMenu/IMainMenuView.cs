using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Views.GameResources;
using Project.Scripts.Game.Areas.Views.Monster;

namespace Project.Scripts.Game.Areas.Views.Canvas
{
    public interface IMainMenuView
    {
        public IGameResourcesView GetMoneyView { get; }
        public IGameResourcesView GetDamagePerTapView { get; }
        public IMonsterView GetMonsterView { get; }
        public ILevelView GetLevelView { get; }
    }
}