using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.GameResources
{
    public class DamagePerTapView : MonoBehaviour, IGameResourcesView
    {
        [SerializeField] private TextMeshProUGUI _damagePerTapView;

        public void SetAmountOfResources(int amountOfResources)
        {
            string amountOfResourcesInString = Convert.ToString(amountOfResources);
            _damagePerTapView.text = amountOfResourcesInString;
        }
    }
}