using UnityEngine;

namespace Project.Scripts.Game.Areas.GameResource.Config
{
    public interface IGameResourceConfig
    {
        public int StartAmount { get; }
        public string Id { get; }
        public Sprite GameResourceSprite { get; }
    }
}