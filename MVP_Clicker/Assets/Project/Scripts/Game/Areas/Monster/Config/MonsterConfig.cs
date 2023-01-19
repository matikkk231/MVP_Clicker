using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.Config
{
    [CreateAssetMenu(fileName = "NewMonster", menuName = "ScriptableObjects/Monster")]
    public class MonsterConfig : ScriptableObject, IMonsterConfig
    {
        [SerializeField] private int _startFullHp;
        [SerializeField] private int _startRewardForKilling;
        [SerializeField] private string _typeOfRewardForKilling;
        [SerializeField] private string _resourceDamagingMonster;
        [SerializeField] private Sprite _monsterImage;

        public int StartFullHp => _startFullHp;
        public int StartRewardForKilling => _startRewardForKilling;
        public Sprite MonsterImage => _monsterImage;
        public string ResourceDamagingMonster => _resourceDamagingMonster;
        public string TypeOfRewardForKilling => _typeOfRewardForKilling;
    }
}