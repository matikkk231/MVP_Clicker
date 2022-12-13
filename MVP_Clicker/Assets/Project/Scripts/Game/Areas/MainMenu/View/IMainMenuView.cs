using Project.Scripts.Game.Areas.GameResources.View;
using Project.Scripts.Game.Areas.Monster.View;
using Project.Scripts.Game.Areas.Resource.View;

public interface IMainMenuView 
{
    IGameResourcesView GameResources { get; }
    IMonsterView Monster { get; }
}
