using System;
using Project.Scripts.Game.Areas.Monster.Config;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public event Action Damaged;

        [SerializeField] private TextMeshProUGUI _currentHp;
        [SerializeField] private Image _monsterImage;

        

        public void SetCurrentHp(int currentHp)
        {
            _currentHp.text = Convert.ToString(currentHp);
        }

        public void SetMonsterImage(Sprite monsterImage)
        {
            _monsterImage.sprite = monsterImage;
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }
    }
}