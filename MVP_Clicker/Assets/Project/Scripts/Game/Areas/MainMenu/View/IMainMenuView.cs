using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.LevelSystem.View;
using Project.Scripts.Game.Areas.Monster.View;

public interface IMainMenuView
{
    IGameResourcesView GameResources { get; }
    IMonsterView Monster { get; }
    ILevelSystemView LevelSystem { get; }
}