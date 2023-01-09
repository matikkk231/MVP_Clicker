using Project.Scripts.Game.Areas.BonusesShop.Data;
using Project.Scripts.Game.Areas.GameResources.Data;
using Project.Scripts.Game.Areas.LevelSystem.Data;
using Project.Scripts.Game.Areas.Monster.Data;

namespace Project.Scripts.Game.Base.GameData
{
    public interface IGameData
    {
        IGameResourcesData GameResources { get; }
        IMonsterData Monster { get; }
        ILevelSystemData LevelSystem{ get; }
        
        IBonusesShopData BonusesShop { get; }
    }
}