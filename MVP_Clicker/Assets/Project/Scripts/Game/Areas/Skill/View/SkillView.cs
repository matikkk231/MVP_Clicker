using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.Skill.View
{
    public class SkillView : MonoBehaviour, ISkillView
    {
        public event Action Activated;

        private float _currentShadowIntensity;

        [SerializeField] private Image _cooldownShadow;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _recoveryDuration;
        [SerializeField] private Image _skillIcon;

        public string Description
        {
            get => _description.text;
            set => _description.text = value;
        }

        public string Name
        {
            get => _name.text;
            set => _name.text = value;
        }

        public int RecoveryDuration
        {
            set => _recoveryDuration.text = value.ToString();
        }

        public Sprite SkillIcon
        {
            get => _skillIcon.sprite;
            set => _skillIcon.sprite = value;
        }

        public void ActivateSkill()
        {
            Activated?.Invoke();
        }

        public void SetShadowIntensityOnSkill(float intensityMultiple)
        {
            float maxIntensity = 200;
            _cooldownShadow.color = new Color(0, 0, 0, maxIntensity * intensityMultiple);
        }
    }
}