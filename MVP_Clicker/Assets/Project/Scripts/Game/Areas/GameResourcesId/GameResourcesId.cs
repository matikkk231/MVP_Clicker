using Project.Scripts.Game.Areas.GameResources.Config;
using Project.Scripts.Game.Areas.GameResources.Data;

namespace Project.Scripts.Game.Areas.GameResourcesId
{
    public class GameResourcesId : IGameResourcesId
    {
        public string Money { get; }
        public string DamagePerTap { get; }

        public GameResourcesId(IGameResourcesConfig config)
        {
            Money = config.Money.Id;
            DamagePerTap = config.DamagePerTap.Id;
        }

        public GameResourcesId(IGameResourcesData data)
        {
            Money = data.Money.Id;
            DamagePerTap = data.DamagePerTap.Id;
        }
    }
}