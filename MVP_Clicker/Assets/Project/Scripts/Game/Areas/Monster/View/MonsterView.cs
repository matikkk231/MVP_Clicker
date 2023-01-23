using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Random = System.Random;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public event Action Damaged;

        [SerializeField] private TextMeshProUGUI _currentHp;
        [SerializeField] private Image _monsterImage;

        public List<Sprite> PullOfMonsterSprites { get; } = new();

        public void SetCurrentHp(int currentHp)
        {
            _currentHp.text = Convert.ToString(currentHp);
        }

        public void SetMonsterImage(Sprite monsterImage)
        {
            if (monsterImage != null)
            {
                _monsterImage.sprite = monsterImage;
            }
        }

        public void UpdateImageRandomlyFromPull()
        {
            var random = new Random();
            int randomInd = random.Next(0, PullOfMonsterSprites.Count);

            SetMonsterImage(PullOfMonsterSprites[randomInd]);
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }
    }
}