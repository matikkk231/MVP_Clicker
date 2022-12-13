using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Resource.View
{
    public class GameResourceView : MonoBehaviour, IGameResourceView
    {
        [SerializeField] private TextMeshProUGUI _amountText;

        public void SetAmount(int amount)
        {
            _amountText.text = Convert.ToString(amount);
        }
    }
}