using UnityEngine;

namespace Project.Scripts.Core.ViewCreate
{
    public class ViewCreate<T> : IViewCreate<T> where T : MonoBehaviour
    {
        private readonly T _prefab;

        public ViewCreate(T prefab)
        {
            _prefab = prefab;
        }
        public IViewBox<T> CreateObject()
        {
            var viewObject = GameObject.Instantiate(_prefab);
            var viewBox = new ViewBox<T>(viewObject);
            return viewBox;

        }
    }
}