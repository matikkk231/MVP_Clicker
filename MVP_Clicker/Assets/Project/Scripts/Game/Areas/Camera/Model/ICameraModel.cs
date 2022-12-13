using System;
using UnityEngine;

public interface ICameraModel
{
    event Action Updated;
    Vector3 Position { get; }
}