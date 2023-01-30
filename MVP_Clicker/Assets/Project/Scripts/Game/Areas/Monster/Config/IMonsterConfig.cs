using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.Config
{
    public interface IMonsterConfig
    {
        public int StartFullHp { get; }
        public int StartRewardForKilling { get; }
        public Sprite StartMonsterImage { get; }
        public string TypeOfRewardForKilling { get; }
        public string ResourceDamagingMonster { get; }
        public string ResourceDamagingMonsterEverySecond { get; }
        public List<Sprite> MonsterImages { get; }
    }
}