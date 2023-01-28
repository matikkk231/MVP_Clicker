using System.Collections.Generic;
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
        [SerializeField] private string _resourceDamagingMonsterEverySecond;
        [SerializeField] private Sprite _startMonsterImage;
        [SerializeField] private List<Sprite> _monsterImages;

        public int StartFullHp => _startFullHp;
        public int StartRewardForKilling => _startRewardForKilling;
        public Sprite StartMonsterImage => _startMonsterImage;
        public string ResourceDamagingMonster => _resourceDamagingMonster;
        public string ResourceDamagingMonsterEverySecond => _resourceDamagingMonsterEverySecond;
        public List<Sprite> MonsterImages => _monsterImages;
        public string TypeOfRewardForKilling => _typeOfRewardForKilling;
    }
}