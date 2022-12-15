using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.LevelSystem.View
{
    public class LevelSystemView : MonoBehaviour, ILevelSystemView
    {
        [SerializeField] private TextMeshProUGUI _currentLevelText;

        public void SetCurrentLevel(int level)
        {
            _currentLevelText.text = Convert.ToString(level);
        }
    }
}