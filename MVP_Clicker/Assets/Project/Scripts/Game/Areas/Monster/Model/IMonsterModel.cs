using System;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public interface IMonsterModel
    {
        event Action Updated;
        event Action Damaged;
        event Action Died;
        int CurrentHp { get; set; }
        int FullHp { get; }
        int RewardForKilling { get; }

        void Damage();
        void Die();
    }
}