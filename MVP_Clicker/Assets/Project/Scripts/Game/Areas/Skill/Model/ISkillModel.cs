using System;

namespace Project.Scripts.Game.Areas.Skill.Model
{
    public interface ISkillModel
    {
        public event Action<float> CooldownUpdated;

        public string Id { get; set; }
        public void Activate();
    }
}