using System;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Project.Scripts.Game.Areas.Resource.View
{
    public class GameResourceView : MonoBehaviour, IGameResourceView
    {
        [SerializeField] private TextMeshProUGUI _amountText;
        [SerializeField] private Image _gameResourceImage;

        public void SetAmount(int amount)
        {
            _amountText.text = Convert.ToString(amount);
        }

        public void SetSprite(Sprite resourceSprite)
        {
            _gameResourceImage.sprite = resourceSprite;
        }
    }
}