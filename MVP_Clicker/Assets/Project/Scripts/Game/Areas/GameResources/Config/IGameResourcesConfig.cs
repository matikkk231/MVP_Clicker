using Project.Scripts.Game.Areas.GameResource.Config;

namespace Project.Scripts.Game.Areas.GameResources.Config
{
    public interface IGameResourcesConfig
    {
        public IGameResourceConfig Money { get; }
        public IGameResourceConfig DamagePerTap { get; }
    }
}