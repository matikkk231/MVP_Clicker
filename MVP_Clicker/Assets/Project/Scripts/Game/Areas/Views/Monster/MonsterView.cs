using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.Monster
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public event Action GotDamagedByTap;

        [SerializeField] private GameObject _objectWithMonsterHP;
        [SerializeField] private GameObject _clickableMonsterButton;


        public void SetAmountOfMonsterHP(int amountOfHP)
        {
            string amountOfHPInString = Convert.ToString(amountOfHP);
            _objectWithMonsterHP.GetComponent<TextMeshProUGUI>().text = "HP: " + amountOfHPInString;
        }

        public void DamageByTap()
        {
            GotDamagedByTap?.Invoke();
        }
    }
}