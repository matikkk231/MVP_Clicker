using UnityEngine;

namespace Project.Scripts.Game.Areas.Views.CameraView
{
    public class CameraView: MonoBehaviour, ICameraView
    {
        [SerializeField] private Transform _transform;
        
        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}