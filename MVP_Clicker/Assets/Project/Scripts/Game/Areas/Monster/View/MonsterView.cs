using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public event Action Damaged;

        [SerializeField] private TextMeshProUGUI _currentHP;

        public void SetCurrentHP(int currentHP)
        {
            _currentHP.text = Convert.ToString(currentHP);
        }

        public void Damage()
        {
            Damaged?.Invoke();
        }
    }
}