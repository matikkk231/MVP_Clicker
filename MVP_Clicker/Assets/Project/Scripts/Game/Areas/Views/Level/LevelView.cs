using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.GameResources
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private GameObject _objectWithTextMeshProGUI;

        public void SetCurrentLevel(int currentLevel)
        {
            string currentLevelInString = Convert.ToString(currentLevel);
            _objectWithTextMeshProGUI.GetComponent<TextMeshProUGUI>().text = currentLevelInString;
        }
    }
}