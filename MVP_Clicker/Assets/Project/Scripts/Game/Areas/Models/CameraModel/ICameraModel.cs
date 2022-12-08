using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Models.CameraModel
{
    public interface ICameraModel
    {
        public Vector3 Position { get; set; }

        public event Action Updated;
    }
}