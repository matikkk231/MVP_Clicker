using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.Config
{
    public interface IMonsterConfig
    {
        public int StartFullHp { get; }
        public int StartRewardForKilling { get; }
        public Sprite MonsterImage { get; }
        public string TypeOfRewardForKilling { get; }
        public string ResourceDamagingMonster { get; }
    }
}