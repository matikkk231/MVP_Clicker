using Project.Scripts.Game.Areas.BonusesShop.Model;
using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.SkillMenu.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public interface IMainMenuModel
    {
        IGameResourcesModel GameResources { get; }
        IMonsterModel Monster { get; }
        MonsterLogicHandlerModel MonsterLogicHandler { get; }
        ILevelSystemModel LevelSystem { get; }
        IBonusesShopModel BonusesShop { get; }
        ISkillMenuModel SkillMenu { get; }
    }
}