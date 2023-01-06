using System;

namespace Project.Scripts.Game.Areas.Resource.Model
{
    public class GameResourceModel : IGameResourceModel
    {
        public event Action Updated;

        private int _amount;

        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                Updated?.Invoke();
            }
        }

        public string Id { get; }

        public GameResourceModel(string id, int amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}