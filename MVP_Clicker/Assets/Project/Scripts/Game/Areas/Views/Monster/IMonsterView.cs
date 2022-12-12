using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.Monster
{
    public interface IMonsterView
    {
        public event Action GotDamagedByTap;
        public void SetAmountOfMonsterHP(int amountOfHP);

        public void DamageByTap();
     
    }
}