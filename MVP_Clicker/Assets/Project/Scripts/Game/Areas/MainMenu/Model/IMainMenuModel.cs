using Project.Scripts.Game.Areas.Achievements.Model;
using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public interface IMainMenuModel
    {
        IGameResourcesModel GameResources { get; }
        IMonsterModel Monster { get; }
        MonsterLogicHandlerModel MonsterLogicHandler { get; }
        ILevelSystemModel LevelSystem { get; }
        IBonusesShopModel BonusesShop { get; }
        IAchievementsModel Achievements { get; }
    }
}