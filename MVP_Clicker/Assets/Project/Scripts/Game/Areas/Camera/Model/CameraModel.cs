using System;
using UnityEngine;

public class CameraModel : ICameraModel
{
    public event Action Updated;
    private Vector3 _position;

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