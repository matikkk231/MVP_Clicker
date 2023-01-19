using System;
using Project.Scripts.Game.Areas.GameResource.Data;

namespace Project.Scripts.Game.Areas.Resource.Model
{
    public class GameResourceModel : IGameResourceModel
    {
        public event Action Updated;

        private readonly IGameResourceData _data;
        private int _amount;

        public int Amount
        {
            get => _data.Amount;
            set
            {
                _data.Amount = value;
                Updated?.Invoke();
            }
        }

        public string Id => _data.Id;

        public GameResourceModel(IGameResourceData data)
        {
            _data = data;
        }
    }
}