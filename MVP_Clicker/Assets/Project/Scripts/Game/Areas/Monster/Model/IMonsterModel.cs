using System;

namespace Project.Scripts.Game.Areas.Monster.Model
{
    public interface IMonsterModel
    {
        event Action Updated;
        event Action Damaged;
        event Action Died;
        int CurrentHP { get; set; }
        int FullHP { get; set; }
        int RewardForKilling { get; set; }

        void Damage();
        void Die();
    }
}