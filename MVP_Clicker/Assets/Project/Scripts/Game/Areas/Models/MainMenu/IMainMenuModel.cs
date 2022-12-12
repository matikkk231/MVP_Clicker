using Project.Scripts.Game.Areas.Models.GameResources;
using Project.Scripts.Game.Areas.Models.Monster;
using Project.Scripts.Game.Areas.Views.GameResources;

namespace Project.Scripts.Game.Areas.Models.Canvas
{
    public interface IMainMenuModel
    {
        public IGameResourcesModel GetMoneyModel { get; }
        public IGameResourcesModel GetDamagePerTapModel { get; }
        public IMonsterModel GetMonsterModel { get; }
        public ILevelModel GetLevelModel { get; }
    }
}