using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.GameResources.Data
{
    public interface IGameResourcesData
    {
        IGameResourceData Money { get; }
        IGameResourceData DamagePerTap { get; }
    }
}