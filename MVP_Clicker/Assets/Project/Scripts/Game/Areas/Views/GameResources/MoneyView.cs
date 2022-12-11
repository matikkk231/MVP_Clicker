using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.GameResources
{
    public class MoneyView : MonoBehaviour, IGameResourcesView
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        public void SetAmountOfResources(int amountOfMoney)
        {
            string amountOfMoneyInText = Convert.ToString(amountOfMoney);
            _textMeshProUGUI.text = amountOfMoneyInText;
        }
    }
}