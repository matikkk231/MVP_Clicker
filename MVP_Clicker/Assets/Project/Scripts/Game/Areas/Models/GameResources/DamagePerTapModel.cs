using System;

namespace Project.Scripts.Game.Areas.Models.GameResources
{
    public class DamagePerTapModel : IGameResourcesModel
    {
        public event Action Updated;

        private int _amountOfDamagePerTap;

        public int AmountOfResourseType
        {
            get => _amountOfDamagePerTap;
            set
            {
                _amountOfDamagePerTap = value;
                Updated?.Invoke();
            }
        }

        public DamagePerTapModel()
        {
            _amountOfDamagePerTap = 1;
        }

      
    }
}