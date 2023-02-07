using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.Config
{
    [CreateAssetMenu(fileName = "newSkill", menuName = "ScriptableObjects/Skill")]
    public class SkillConfig : ScriptableObject, ISkillConfig
    {
        [SerializeField] private int _recoveryDuration;
        [SerializeField] private int _activityDuration;
        [SerializeField] private int _boostValue;
        [SerializeField] private Sprite _skillIcon;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _id;

        public string Id => _id;
        public int RecoveryDuration => _recoveryDuration;
        public int ActivityDuration => _activityDuration;
        public int BoostValue => _boostValue;
        public Sprite SkillIcon => _skillIcon;
        public string Name => _name;
        public string Description => _description;
    }
}