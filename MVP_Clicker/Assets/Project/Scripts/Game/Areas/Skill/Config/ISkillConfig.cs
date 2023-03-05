using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.Config
{
    public interface ISkillConfig
    {
        public int RecoveryDuration { get; }
        public int ActivityDuration { get; }
        public int BoostValue { get; }
        public Sprite SkillIcon { get; }
        public string Name { get; }
        public string Description { get; }
        public string Id { get; }
    }
}