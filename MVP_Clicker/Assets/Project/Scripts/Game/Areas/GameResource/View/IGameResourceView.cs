using UnityEngine;

namespace Project.Scripts.Game.Areas.Resource.View
{
    public interface IGameResourceView
    {
        void SetAmount(int amount);
        public void SetSprite(Sprite resourceSprite);
    }
}