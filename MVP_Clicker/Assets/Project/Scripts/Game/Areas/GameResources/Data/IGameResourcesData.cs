using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.GameResources.Data
{
    public interface IGameResourcesData
    {
        bool IsInitialized { get; set; }
        IGameResourceData Money { get; }
        IGameResourceData DamagePerTap { get; }
    }
}