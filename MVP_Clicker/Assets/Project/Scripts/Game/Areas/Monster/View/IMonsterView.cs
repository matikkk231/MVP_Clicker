using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public interface IMonsterView
    {
        public event Action Damaged;
        
        void SetCurrentHp(int currentHp);

        public void SetMonsterImage(Sprite monsterImage);
    }
}