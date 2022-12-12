using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Models.GameResources
{
    public class MoneyModel : IGameResourcesModel
    {
        public event Action Updated;

        private int _amountOfMoney;


        public int AmountOfResourseType
        {
            get => _amountOfMoney;
            set
            {
                _amountOfMoney = value;
                Updated?.Invoke();
            }
        }
    }
}