using UnityEngine;

namespace Project.Scripts.Core.ViewCreate
{
    public class ViewCreator<T> : IViewCreator<T> where T : MonoBehaviour
    {
        private readonly T _prefab;

        public ViewCreator(T prefab)
        {
            _prefab = prefab;
        }
        public IBoxView<T> CreateObject()
        {
            var viewObject = GameObject.Instantiate(_prefab);
            var viewBox = new BoxView<T>(viewObject);
            return viewBox;

        }
    }
}