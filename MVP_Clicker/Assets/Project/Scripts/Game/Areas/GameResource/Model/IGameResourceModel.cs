using System;

namespace Project.Scripts.Game.Areas.Resource.Model
{
    public interface IGameResourceModel
    {
        event Action Updated;

        int Amount { get; set; }
    }
}