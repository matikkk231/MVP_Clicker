using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public interface IMonsterView
    {
        public event Action Damaged;

        void SetCurrentHp(int currentHp);

        public void SetMonsterImage(Sprite monsterImage);

        public void UpdateImageRandomlyFromPull();

        public List<Sprite> PullOfMonsterSprites { get; }
    }
}