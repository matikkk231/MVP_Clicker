using Project.Scripts.Game.Areas.Models.GameResources;

namespace Project.Scripts.Game.Areas.Models.Canvas
{
    public interface IMainMenuModel
    {
        public IGameResourcesModel GetMoneyModel { get; }
    }
}