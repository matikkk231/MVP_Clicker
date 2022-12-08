using System;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Models.CameraModel
{
    public class CameraModel : ICameraModel
    {
        private Vector3 _position;

        public event Action Updated;
        
        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                Updated?.Invoke();
            }
        }
    }
}