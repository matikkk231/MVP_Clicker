using Project.Scripts.Game.Areas.Resource.View;

namespace Project.Scripts.Game.Areas.GameResources.View
{
    public interface IGameResourcesView
    {
        IGameResourceView Money { get; }
        IGameResourceView DamagePerTap { get; }
    }
}