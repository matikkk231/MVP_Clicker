using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public event Action Damaged;

        [SerializeField] private TextMeshProUGUI _currentHp;

        public void SetCurrentHp(int currentHp)
        {
            _currentHp.text = Convert.ToString(currentHp);
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }
    }
}