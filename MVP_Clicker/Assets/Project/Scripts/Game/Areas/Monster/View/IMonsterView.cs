using System;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public interface IMonsterView
    {
        public event Action Damaged;
        void SetCurrentHP(int currentHP);

        void Damage();
        // using in button, dont know why its gray
    }
}