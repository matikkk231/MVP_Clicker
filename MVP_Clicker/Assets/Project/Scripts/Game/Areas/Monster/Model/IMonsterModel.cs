using System;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public interface IMonsterModel
    {
        event Action Updated;
        event Action Damaged;
        event Action Died;

        int CurrentHp { get; set; }
        int FullHp { get; set; }
        int RewardForKilling { get; set; }

        void Damage();
        void Die();
    }
}