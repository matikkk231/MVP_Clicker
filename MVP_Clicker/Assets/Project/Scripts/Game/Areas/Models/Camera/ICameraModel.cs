using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Models.Camera
{
    public interface ICameraModel
    {
        public event Action Updated;

        public Vector3 Position { get; set; }
    }
}