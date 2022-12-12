using System;
using UnityEngine.SocialPlatforms.Impl;

namespace Project.Scripts.Game.Areas.Models.GameResources
{
    public interface IGameResourcesModel
    {
        event Action Updated;
        public int AmountOfResourseType { get; set; }
    }
}