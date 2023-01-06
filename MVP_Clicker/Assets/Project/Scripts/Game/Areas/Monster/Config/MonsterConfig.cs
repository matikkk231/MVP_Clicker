using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.Config
{
    [CreateAssetMenu(fileName = "NewMonster", menuName = "ScriptableObjects/Monster")]
    public class MonsterConfig : ScriptableObject, IMonsterConfig
    {
        [SerializeField] private int _startFullHp;
        [SerializeField] private int _startRewardForKilling;

        public int StartFullHp => _startFullHp;
        public int StartRewardForKilling => _startRewardForKilling;
    }
}