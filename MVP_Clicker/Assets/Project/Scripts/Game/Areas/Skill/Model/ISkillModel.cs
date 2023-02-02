using System;

namespace Project.Scripts.Game.Areas.Skill.Model
{
    public interface ISkillModel
    {
        public event Action<float> UpdatedCooldown;

        public string Id { get; set; }
        public void TryActivate();
    }
}