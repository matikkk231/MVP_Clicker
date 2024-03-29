using Project.Scripts.Game.Areas.Achievements.View;
using Project.Scripts.Game.Areas.BonusesShop.View;
using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.LevelSystem.View;
using Project.Scripts.Game.Areas.Monster.View;
using Project.Scripts.Game.Areas.Skills.View;

public interface IMainMenuView
{
    IGameResourcesView GameResources { get; }
    IMonsterView Monster { get; }
    ILevelSystemView LevelSystem { get; }
    IBonusesShopView BonusesShopView { get; }
    IAchievementsView Achievements { get; }
    IBonusesShopView BonusesShop { get; }
    ISkillMenuView SkillMenu { get; }
}