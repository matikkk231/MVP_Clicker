using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Skill.View
{
    public interface ISkillView
    {
        public event Action Activated;

        public string Description { set; }
        public string Name { set; }
        public int RecoveryDuration { set; }
        public Sprite SkillIcon { set; }

        public void SetShadowIntensityOnSkill(float intensityMultiple);
    }
}