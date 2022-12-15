using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.LevelSystem.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public interface IMainMenuModel
    {
        IGameResourcesModel GameResources { get; }
        IMonsterModel Monster { get; }

        MonsterLogicHandlerModel MonsterLogicHandlerModel { get; }
        ILevelSystemModel LevelSystem { get; }
    }
}